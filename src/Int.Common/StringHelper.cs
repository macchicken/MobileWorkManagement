using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Int.Common
{
    public static class StringHelper
    {
        public static bool IsCaseInsensitiveMatch(string str1, string str2)
        {
            return string.Equals(str1, str2, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// 截取指定字节长度的字符串
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <param name="len">截取字节长度</param>
        /// <returns></returns>
        public static string CutByteString(string str, int len)
        {
            string result = string.Empty;// 最终返回的结果
            if (string.IsNullOrEmpty(str)) { return result; }
            int byteLen = System.Text.Encoding.Default.GetByteCount(str);// 单字节字符长度
            int charLen = str.Length;// 把字符平等对待时的字符串长度
            int byteCount = 0;// 记录读取进度
            int pos = 0;// 记录截取位置
            if (byteLen > len)
            {
                for (int i = 0; i < charLen; i++)
                {
                    if (Convert.ToInt32(str.ToCharArray()[i]) > 255)// 按中文字符计算加2
                    { byteCount += 2; }
                    else// 按英文字符计算加1
                    { byteCount += 1; }
                    if (byteCount > len)// 超出时只记下上一个有效位置
                    {
                        pos = i;
                        break;
                    }
                    else if (byteCount == len)// 记下当前位置
                    {
                        pos = i + 1;
                        break;
                    }
                }
                if (pos >= 0)
                { result = str.Substring(0, pos) + "..."; }
            }
            else
            { result = str; }
            return result;
        }

        /// <summary>
        /// 截取指定字节长度的字符串
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <param name="startIndex">起始位置</param>
        /// <param name="len">截取字节长度</param>
        /// <returns></returns>
        public static string CutByteString(string str, int startIndex, int len)
        {
            string result = string.Empty;// 最终返回的结果
            if (string.IsNullOrEmpty(str)) { return result; }

            int byteLen = System.Text.Encoding.Default.GetByteCount(str);// 单字节字符长度
            int charLen = str.Length;// 把字符平等对待时的字符串长度

            if (startIndex == 0)
            { return CutByteString(str, len); }
            else if (startIndex >= byteLen)
            { return result; }
            else //startIndex < byteLen
            {
                int AllLen = startIndex + len;
                int byteCountStart = 0;// 记录读取进度
                int byteCountEnd = 0;// 记录读取进度
                int startpos = 0;// 记录截取位置                
                int endpos = 0;// 记录截取位置
                for (int i = 0; i < charLen; i++)
                {
                    if (Convert.ToInt32(str.ToCharArray()[i]) > 255)// 按中文字符计算加2
                    { byteCountStart += 2; }
                    else// 按英文字符计算加1
                    { byteCountStart += 1; }
                    if (byteCountStart > startIndex)// 超出时只记下上一个有效位置
                    {
                        startpos = i;
                        AllLen = startIndex + len - 1;
                        break;
                    }
                    else if (byteCountStart == startIndex)// 记下当前位置
                    {
                        startpos = i + 1;
                        break;
                    }
                }

                if (startIndex + len <= byteLen)//截取字符在总长以内
                {
                    for (int i = 0; i < charLen; i++)
                    {
                        if (Convert.ToInt32(str.ToCharArray()[i]) > 255)// 按中文字符计算加2
                        { byteCountEnd += 2; }
                        else// 按英文字符计算加1
                        { byteCountEnd += 1; }
                        if (byteCountEnd > AllLen)// 超出时只记下上一个有效位置
                        {
                            endpos = i;
                            break;
                        }
                        else if (byteCountEnd == AllLen)// 记下当前位置
                        {
                            endpos = i + 1;
                            break;
                        }
                    }
                    endpos = endpos - startpos;
                }
                else if (startIndex + len > byteLen)//截取字符超出总长
                {
                    endpos = charLen - startpos;
                }
                if (endpos >= 0)
                {
                    result = str.Substring(startpos, endpos) + "...";
                }
            }
            return result;
        }

        /// <summary>
        /// 正则表达式取值
        /// </summary>
        /// <param name="htmlCode">HTML代码</param>
        /// <param name="regexString">正则表达式</param>
        /// <param name="groupKey">正则表达式分组关键字</param>
        /// <param name="rightToLeft">是否从右到左</param>
        /// <returns></returns>
        public static string[] GetRegValue(string htmlCode, string regexString, string groupKey, bool rightToLeft)
        {
            MatchCollection m;
            Regex r;
            if (rightToLeft == true)
            {
                r = new Regex(regexString, RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.RightToLeft);
            }
            else
            {
                r = new Regex(regexString, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            }
            m = r.Matches(htmlCode);
            string[] matchValue = new string[m.Count];
            for (int i = 0; i < m.Count; i++)
            {
                matchValue[i] = m[i].Groups[groupKey].Value;
            }
            return matchValue;
        }

        /// <summary>
        /// 获得标签的属性值
        /// </summary>
        /// <param name="htmlTag"></param>
        /// <param name="attributeName"></param>
        /// <returns></returns>
        public static string AttributeValue(string htmlTag, string attributeName)
        {
            //前缀符号，要么为空，要么是空格/双引号/单引号/竖线/冒号……你还可以自己加入其他的符号
            string prefixCHAR = (htmlTag.StartsWith(attributeName + "=")) ? "(.{0})" : "([\"'\\s\\|:]{1})";
            string regexString = prefixCHAR + attributeName + "=(\"|')(?<" + attributeName + ">.*?[^\\\\]{1})(\\2)";
            string[] _att = GetRegValue(htmlTag, regexString, attributeName, false);
            if (_att.Length > 0)
                return _att[0].ToString();
            else
                return "";
        }
    }
}
