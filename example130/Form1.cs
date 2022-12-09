using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace example130
{
    public partial class Form1 : Form
    {
        bool direct = false;
        //false면 한국어->다른나라언어
        //true면 나른나라언어에서 -> 한국어

        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string url = "https://openapi.naver.com/v1/papago/n2mt";
            string client_id = "KiGVFReRf7J4nEJA1prv";
            string client_secret = "51G1ca5rb8";


            WebRequest wr = WebRequest.Create(url);
            wr.Headers.Add("X-Naver-Client-Id", client_id);
            wr.Headers.Add("X-Naver-Client-Secret", client_secret);
            wr.Method = "POST";

            string query = "";

            string source = "";
            string target = "";
            if (direct)
            {
                //다른언어를 한국어로
                query = richTextBox2.Text;
                switch (comboBox1.SelectedItem.ToString())
                {
                    case "한국어" :
                        source = "ko";
                        break;
                    case "영어":
                        source = "en";
                        break;
                    case "일본어":
                        source = "ja";
                        break;
                    case "중국어(간체)":
                        source = "zh-CN";
                        break;
                    case "중국어(번체)":
                        source = "zh-TW";
                        break;
                    case "베트남어":
                        source = "vi";
                        break;
                    case "인도네시아어":
                        source = "id";
                        break;
                    case "태국어":
                        source = "th";
                        break;
                    case "독일어":
                        source = "de";
                        break;
                    case "러시아어":
                        source = "ru";
                        break;
                    case "스페인어":
                        source = "es";
                        break;
                    case "이탈리아어":
                        source = "it";
                        break;
                    case "프랑스어":
                        source = "fr";
                        break;
                    default :
                        break;
                }
                switch (comboBox2.SelectedItem.ToString())
                {
                    case "한국어":
                        target = "ko";
                        break;
                    case "영어":
                        target = "en";
                        break;
                    case "일본어":
                        target = "ja";
                        break;
                    case "중국어(간체)":
                        target = "zh-CN";
                        break;
                    case "중국어(번체)":
                        target = "zh-TW";
                        break;
                    case "베트남어":
                        target = "vi";
                        break;
                    case "인도네시아어":
                        target = "id";
                        break;
                    case "태국어":
                        target = "th";
                        break;
                    case "독일어":
                        target = "de";
                        break;
                    case "러시아어":
                        target = "ru";
                        break;
                    case "스페인어":
                        target = "es";
                        break;
                    case "이탈리아어":
                        target = "it";
                        break;
                    case "프랑스어":
                        target = "fr";
                        break;
                    default:
                        break;
                }
            }
            else
            {
                //한국어를 다른언어로
                query = richTextBox1.Text;
                switch (comboBox2.SelectedItem.ToString())
                {
                    case "한국어":
                        source = "ko";
                        break;
                    case "영어":
                        source = "en";
                        break;
                    case "일본어":
                        source = "ja";
                        break;
                    case "중국어(간체)":
                        source = "zh-CN";
                        break;
                    case "중국어(번체)":
                        source = "zh-TW";
                        break;
                    case "베트남어":
                        source = "vi";
                        break;
                    case "인도네시아어":
                        source = "id";
                        break;
                    case "태국어":
                        source = "th";
                        break;
                    case "독일어":
                        source = "de";
                        break;
                    case "러시아어":
                        source = "ru";
                        break;
                    case "스페인어":
                        source = "es";
                        break;
                    case "이탈리아어":
                        source = "it";
                        break;
                    case "프랑스어":
                        source = "fr";
                        break;
                    default:
                        break;
                }

                switch (comboBox1.SelectedItem.ToString())
                {
                    case "한국어":
                        target = "ko";
                        break;
                    case "영어":
                        target = "en";
                        break;
                    case "일본어":
                        target = "ja";
                        break;
                    case "중국어(간체)":
                        target = "zh-CN";
                        break;
                    case "중국어(번체)":
                        target = "zh-TW";
                        break;
                    case "베트남어":
                        target = "vi";
                        break;
                    case "인도네시아어":
                        target = "id";
                        break;
                    case "태국어":
                        target = "th";
                        break;
                    case "독일어":
                        target = "de";
                        break;
                    case "러시아어":
                        target = "ru";
                        break;
                    case "스페인어":
                        target = "es";
                        break;
                    case "이탈리아어":
                        target = "it";
                        break;
                    case "프랑스어":
                        target = "fr";
                        break;
                    default:
                        break;
                }
            }


            byte[] byteDataParams = Encoding.UTF8.GetBytes("source=" + source + "&target=" + target + "&text=" + query);
            wr.ContentType = "application/x-www-form-urlencoded";
            wr.ContentLength = byteDataParams.Length;
            Stream st = wr.GetRequestStream();
            st.Write(byteDataParams, 0, byteDataParams.Length);
            st.Close();

            WebResponse wrs = wr.GetResponse();
            Stream stream = wrs.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            string text = reader.ReadToEnd();
            stream.Close();
            wrs.Close();
            reader.Close();

            JObject json = JObject.Parse(text);

            if (direct)
            {
                richTextBox1.Text = json["message"]["result"]["translatedText"].ToString();
            }
            else
            {
                richTextBox2.Text = json["message"]["result"]["translatedText"].ToString();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (direct)
            {
                //다른언어를 한국어로 바꾸는경우
                button4.Text = "▶";
                direct = false;

            }
            else
            {
                //한국어를 다른언어로 바꾸는경우
                button4.Text = "◀";
                direct = true;
            }
        }
    }

}
