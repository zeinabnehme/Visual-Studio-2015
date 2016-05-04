//using System;
//using System.Collections.Generic;
//using System.Net;
//using System.Text;
//using System.Web.Http;
//using System.IO;
//using System.Xml;
//namespace SearchClientWebApp.Areas.SME.Controllers
//{
//    public class ReportController : ApiController
//    {
//        public string x;
//        public void SetBasicAuthHeader(WebRequest request, String userName, String userPassword)
//        {
//            string authInfo = userName + ":" + userPassword;
//            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
//            request.Headers["Authorization"] = Convert.ToString("Basic ") + authInfo;
//            x = Convert.ToString("Basic ") + authInfo;
//        }

//        // GET: api/Report
//        public IEnumerable<string> Get(int? id)
//        {
//            dynamic request = WebRequest.Create("http://192.168.0.13:8080/jasperserver/rest/resource/Majmoua_Reports/Display_Name");
//            //?fields=name")
//            SetBasicAuthHeader(request, "houssein", "Ho123456");
//            //request.Headers.Add("X-Mifos-Platform-TenantId", "default")
//            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

//            // Get the stream containing content returned by the server.
//            Stream dataStream = response.GetResponseStream();
//            // Open the stream using a StreamReader for easy access.
//            StreamReader reader = new StreamReader(dataStream);
//            // Read the content.
//            string responseFromServer = reader.ReadToEnd();
//            // MsgBox(responseFromServer)
//            XmlDocument xdoc = new XmlDocument();
//            xdoc.LoadXml(responseFromServer);
//            XmlDocumentFragment xfrag = xdoc.CreateDocumentFragment();
//            xfrag.InnerXml = "<parameter name=\"accountID\">" + id + "</parameter>";
//            xdoc.DocumentElement.AppendChild(xfrag);
//            //MsgBox(xdoc.InnerXml)

//            dynamic webAddr = "http://192.168.0.13:8080/jasperserver/rest/report/Majmoua_Reports/Display_Name?RUN_OUTPUT_FORMAT=PDF";
//            dynamic httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
//            httpWebRequest.Method = "PUT";
//            httpWebRequest.ContentType = "text/xml";
//            SetBasicAuthHeader(httpWebRequest, "houssein", "Ho123456");




//            using (streamWriter == new StreamWriter(httpWebRequest.GetRequestStream()))
//            {
//                //Dim x2 As New XmlDocument()
//                //x2.LoadXml(responseFromServer)
//                string x = xdoc.InnerXml;
//                //MsgBox(x)
//                streamWriter.Write(x);
//                //streamWriter.Flush()
//            }

//            httpWebRequest.CookieContainer = new CookieContainer();





//            // Print the properties of each cookie.



//            HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
//            Stream dataStream2 = httpResponse.GetResponseStream();
//            // Open the stream using a StreamReader for easy access.
//            StreamReader reader2 = new StreamReader(dataStream2, System.Text.Encoding.UTF8);
//            // Read the content.
//            string responseFromServer2 = reader2.ReadToEnd();
//            //    Dim cook As Cookie
//            //For Each cook In httpResponse.Cookies
//            //    msgbox("Cookie:")
//            //    msgbox("{0} = {1}", cook.Name, cook.Value)
//            //    msgbox("Domain: {0}", cook.Domain)
//            //    msgbox("Path: {0}", cook.Path)
//            //    msgbox("Port: {0}", cook.Port)
//            //    msgbox("Secure: {0}", cook.Secure)

//            //    Console.WriteLine("When issued: {0}", cook.TimeStamp)
//            //    Console.WriteLine("Expires: {0} (expired? {1})", cook.Expires, cook.Expired)
//            //    MsgBox("Don't save: {0}", cook.Discard)
//            //    msgbox("Comment: {0}", cook.Comment)
//            //    Console.WriteLine("Uri for comments: {0}", cook.CommentUri)
//            //    MsgBox("Version: RFC {0}", IIf(cook.Version = 1, "2109", "2965"))

//            //    ' Show the string representation of the cookie.
//            //    msgbox("String: {0}", cook.ToString())
//            //Next cook



//            //Dim m As reportitem = JsonConvert.DeserializeObject(Of reportitem)(responseFromServer)
//            //MsgBox(responseFromServer2)
//            //MsgBox(httpResponse.Cookies.Count)
//            XmlDocument doc = new XmlDocument();
//            doc.LoadXml(responseFromServer2);

//            // MsgBox(doc.FirstChild.InnerText)
//            string uuid = doc.FirstChild.Item("uuid").InnerText;
//            //Dim serializer As XmlSerializer = New XmlSerializer(GetType(reportitem), New XmlRootAttribute("reportitem"))
//            //Dim mm As reportitem = CType(serializer.Deserialize(reader2), reportitem)
//            //MsgBox(uuid)

//            dynamic webAddr2 = "http://192.168.0.13:8080/jasperserver/rest/report/" + uuid + "?file=report";
//            dynamic request3 = (HttpWebRequest)WebRequest.Create(webAddr2);
//            SetBasicAuthHeader(request3, "houssein", "Ho123456");

//            CookieContainer helloworld = new CookieContainer();
//            helloworld = httpWebRequest.CookieContainer;
//            request3.CookieContainer = helloworld;

//            HttpWebResponse response3 = (HttpWebResponse)request3.GetResponse();

//            // Get the stream containing content returned by the server.

//            Stream dataStream3 = response3.GetResponseStream();
//            // Open the stream using a StreamReader for easy access.
//            //Dim reader3 As New StreamReader(dataStream3)
//            BinaryReader reader3 = new BinaryReader(dataStream3, System.Text.Encoding.UTF8);
//            // Read the content.

//            //Dim responseFromServer3 As String = reader3.ReadToEnd()
//            Context.Response.Clear();
//            Context.Response.ContentType = ("application/pdf;charset=utf-8");
//            Context.Response.AddHeader("Content-Disposition", "inline;filename=\"FileName.pdf\"");
//            Context.Response.Buffer = true;
//            Context.Response.ContentEncoding = System.Text.Encoding.UTF8;
//            Context.Response.BinaryWrite(reader3.ReadBytes(1000000));
//            //if inline we add         Context.Response.Flush()

//            Context.Response.End();

        

//            return new string[] { "value1", "value2" };
//        }

//        // GET: api/Report/5
//        public string Get(int id)
//        {
//            return "value";
//        }

//        // POST: api/Report
//        public void Post([FromBody]string value)
//        {
//        }

//        // PUT: api/Report/5
//        public void Put(int id, [FromBody]string value)
//        {
//        }

//        // DELETE: api/Report/5
//        public void Delete(int id)
//        {
//        }
//    }
//}
