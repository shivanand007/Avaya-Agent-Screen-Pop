using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Xml;


public partial class GetData : System.Web.UI.Page
{
    string mycon = ConfigurationManager.ConnectionStrings["DB_AB"].ConnectionString;
    string mycon2 = ConfigurationManager.ConnectionStrings["DB_IVR"].ConnectionString;
    TraceSource TS;

    protected void Page_Load(object sender, EventArgs e)


    {

        string ID = Request.QueryString[Constants.Url_Param_ID];
        string AuthStatus = Request.QueryString[Constants.Url_Param_Auth];
        string Co = Request.QueryString[Constants.Url_Param_CO];
        string CusProduct = Request.QueryString[Constants.Url_Param_CP];
        string AcNo = Request.QueryString[Constants.Url_Param_AcNo];

        Trace.Warn("account number  : " + AcNo);
        string Language = Request.QueryString[Constants.Url_Param_L];
        string LastService = Request.QueryString[Constants.Url_Param_LS];
        string AckFlag = Request.QueryString[Constants.Url_Param_Ackf];
        string SkillSetWS = Request.QueryString[Constants.Url_Param_InSkillset];
        string RowID = Request.QueryString[Constants.Url_Param_RowID];
        string Custid = Request.QueryString[Constants.Url_Param_CustomerID];
        string BR = Request.QueryString[Constants.Url_Param_BR];

        Trace.Warn("branch  :: " + BR);
        string CT = Request.QueryString[Constants.Url_Param_CT];
        string TO = Request.QueryString[Constants.Url_Param_TO];
        string V = Request.QueryString[Constants.Url_Param_V];
        string ContactID = Request.QueryString[Constants.Url_Param_ContactID];
        string IsCall = Request.QueryString[Constants.Url_Param_IsCall];
        string CallerId = Request.QueryString[Constants.Url_Param_CallerId];
        string CustomerID = BR + AcNo;

//*****************************getting agent name********************************************************************************

//************************************************************************************************************************

        if (AcNo == string.Empty || BR == string.Empty)
        {
            CusName.Text = string.Empty;
        }
        else
        {

            string NameRequest = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ser=\"http://AB/MW/ABSPARK/Channels/Customer/Inquiry/Services\" xmlns:com=\"http://AB/MW/ABSPARK/Common/Schemas/L2/Common\" xmlns:par=\"http://AB/MW/ABSPARK/Common/Schemas/L2/Party\">\n" +
                    "<soapenv:Header/>\n" +
                    "<soapenv:Body>\n" +
                    "<ser:RetrieveCustomerProfileRequest>\n" +
                    "<Header>\n" +
                    "<com:UUID>2022022310793026</com:UUID>\n" +
                    "<com:Country>JO</com:Country>\n" +
                    "<com:Channel>\n" +
                    "<com:ChannelName>IVR</com:ChannelName>\n" +
                    "<com:ChannelReqTime>2022-02-23T10:17:26</com:ChannelReqTime>\n" +
                    "<com:ChannelTrxRef>2022022310793026</com:ChannelTrxRef>\n" +
                    "</com:Channel>\n" +
                    "<com:ServiceCode>ENQ2591</com:ServiceCode>\n" +
                    "</Header>\n" +
                    "<CustomerIdentifier>\n" +
                    "<par:Identifier>\n" +
                    "<com:Type>ACCOUNTBRANCH</com:Type>\n" +
                    "<com:Value>" + BR + "</com:Value>\n" +
                    "</par:Identifier>\n" +
                    "<par:Identifier>\n" +
                    "<com:Type>ACCOUNTBASIC</com:Type>\n" +
                    "<com:Value>" + AcNo + "</com:Value>\n" +
                    "</par:Identifier>\n" +
                    "</CustomerIdentifier>\n" +
                    "<CustomerCountry>JO</CustomerCountry>\n" +
                    "<TransactionCode>?</TransactionCode>\n" +
                    "</ser:RetrieveCustomerProfileRequest>\n" +
                    "</soapenv:Body>\n" +
                    "</soapenv:Envelope>";
            Trace.Write("*****XML REQUEST :   " + NameRequest);
            string Requrl = "https://10.1.13.39:9130/Customer/Inquiry";
            Trace.Write("******************URL for Request ****" + Requrl);

            HttpWebRequest request4 = (HttpWebRequest)WebRequest.Create(Requrl);
            request4.ContentType = "text/xml;charset=\"UTF-8\"";
            request4.Method = "POST";
            request4.Timeout = 5000;
            request4.Accept = "text/xml";
            byte[] encod56 = Encoding.UTF8.GetBytes(NameRequest);
            request4.ContentLength = encod56.Length;

            Stream stream6 = request4.GetRequestStream();
            stream6.Write(encod56, 0, encod56.Length);
            stream6.Close();
            WebResponse Serviceres7 = request4.GetResponse();
            StreamReader rd4 = new StreamReader(Serviceres7.GetResponseStream());

            string GetCustomernameResponse = rd4.ReadToEnd();
            Trace.Write("*******XML response of web service is  : " + GetCustomernameResponse);

            XmlDocument xmlDoc5 = new XmlDocument();
            xmlDoc5.LoadXml(GetCustomernameResponse);

            XmlNodeList GetCuStNamefirst = xmlDoc5.GetElementsByTagName("CustomerFirstNameEN");
            XmlNodeList GetCuStNameMid = xmlDoc5.GetElementsByTagName("CustomerMiddleNameEN");
            XmlNodeList GetCuStNameLast = xmlDoc5.GetElementsByTagName("CustomerLastNameEN");

            string FullName = GetCuStNamefirst[0].InnerText + GetCuStNameMid[0].InnerText + GetCuStNameLast[0].InnerText;

            Trace.Write("*****Customer Full Name*****  : " + FullName);
            CusName.Text = FullName;
        }

        //display from url

        CallerID.Text = CallerId.ToString();      //URL
        Lang.Text = Language;
        CusType.Text = CT;
        CusID.Text = CustomerID.ToString();
        // CusName.Text = string.Empty;
        AccNo.Text = AcNo.ToString();             //URL
        Country.Text = Co.ToString();             //URL
        CusPro.Text = CusProduct.ToString();      //URL
        Skill.Text = SkillSetWS.ToString();       //URL
        Auth.Text = AuthStatus.ToString();        //URL
        Branch.Text = BR.ToString();              //URL
        Last.Text = LastService.ToString();       //URL

        SWF.Text = "NA";

        string LS = Request.QueryString[Constants.Url_Param_LS];
        string skilltrim = Request.QueryString[Constants.Url_Param_InSkillset].Substring(3);




        if (AuthStatus == "Y")
        {
            Auth.BorderColor = System.Drawing.Color.Green;
            Auth.ForeColor = System.Drawing.Color.Green;

            Approve.Visible = false;
            Reject.Visible = false;
            RejectSuspend.Visible = false;

        }

        if (AuthStatus == "N")
        {
            Auth.BorderColor = System.Drawing.Color.Red;
            Auth.ForeColor = System.Drawing.Color.Red;

            if (LS == "Complete Registration" || LS == "Reactivate service" || LS == "Exceed Retries  Reset TIN")
            {
                Approve.Visible = true;
                Reject.Visible = true;
                RejectSuspend.Visible = true;
            }

            else
            {
                Approve.Visible = false;
                Reject.Visible = false;
                RejectSuspend.Visible = false;
            }
        }


        string shift = DropDownShift.SelectedValue;
        switch (skilltrim)
        {
            case "ELT_AR":

                CBR.Enabled = true;
                CBR1.Enabled = true;
                CBR2.Enabled = true;
                break;
            case "ELT_EN":
                CBR.Enabled = true;
                CBR1.Enabled = true;
                CBR2.Enabled = true;
                break;
            case "PRM_AR":
                CBR.Enabled = true;
                CBR1.Enabled = true;
                CBR2.Enabled = true;
                break;
            case "PRM_EN":
                CBR.Enabled = true;
                CBR1.Enabled = true;
                CBR2.Enabled = true;
                break;
            case "COR_AR":
                CBR.Enabled = true;
                CBR1.Enabled = true;
                CBR2.Enabled = true;
                break;
            case "COR_EN":
                CBR.Enabled = true;
                CBR1.Enabled = true;
                CBR2.Enabled = true;
                break;
            default:
                CBR.Enabled = false;
                CBR1.Enabled = false;
                CBR2.Enabled = false;
                break;
        }









    }


    protected void DNC1_Click(object sender, EventArgs e)
    {

        try
        {
            string action = "ADD";

            SqlConnection con = new SqlConnection(mycon);
            SqlCommand cmd = new SqlCommand("SP_DNC_ADD", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = action;
            cmd.Parameters.Add("@CallerID", SqlDbType.VarChar).Value = Request.QueryString[Constants.Url_Param_CallerId];
            cmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = Request.QueryString[Constants.Url_Param_CO];

            con.Open();
            cmd.ExecuteNonQuery();

        }
        catch
        {
            string script1 = "alert('Failed To ADD To DNC');";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Info", script1, true);
        }

        string script = "alert('ADDED TO DNC Successfully');";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Info", script, true);

    }

    protected void DNC2_Click(object sender, EventArgs e)
    {
        try
        {
            string action = "REMOVE";

            SqlConnection con = new SqlConnection(mycon);
            SqlCommand cmd = new SqlCommand("SP_DNC_REMOVE", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = action;
            cmd.Parameters.Add("@CallerID", SqlDbType.VarChar).Value = Request.QueryString[Constants.Url_Param_CallerId];


            con.Open();
            cmd.ExecuteNonQuery();
        }
        catch
        {
            string script1 = "alert('Failed To Remove From DNC');";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Info", script1, true);
        }

        string script = "alert('Remove From DNC Successfull');";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Info", script, true);
    }

    protected void CBR1_Click(object sender, EventArgs e)
    {
        // add to CBR


        try
        {



            CBR_Services.CallBackRequest CBRadd = new CBR_Services.CallBackRequest();
            string number = Request.QueryString[Constants.Url_Param_CallerId];
            string skillset = Request.QueryString[Constants.Url_Param_InSkillset];
            string outboundskillset = "OB_" + skillset;
            //string camp_name = "OnAbandoned_0";
            string shift = DropDownShift.SelectedValue;

            string skilltrim = Request.QueryString[Constants.Url_Param_InSkillset].Substring(3);
            string Campaign = "";

            if (shift == "1")
            {
                if (skilltrim == "ELT_AR" || skilltrim == "ELT_EN")
                {
                    Campaign = "ELT_Morning_0";
                }

                else if (skilltrim == "PRM_AR" || skilltrim == "PRM_EN")
                {
                    Campaign = "PRE_Morning_0";
                }

                else if (skilltrim == "COR_AR" || skilltrim == "COR_EN")
                {
                    Campaign = "COR_Morning_0";
                }


            }

            else if (shift == "2")
            {
                if (skilltrim == "ELT_AR" || skilltrim == "ELT_EN")
                {
                    Campaign = "ELT_Afternoon_0";
                }

                else if (skilltrim == "PRM_AR" || skilltrim == "PRM_EN")
                {
                    Campaign = "PRE_Afternoon_0";
                }

                else if (skilltrim == "COR_AR" || skilltrim == "COR_EN")
                {
                    Campaign = "COR_Afternoon_0";
                }

            }

            else if (shift == "3")
            {
                if (skilltrim == "ELT_AR" || skilltrim == "ELT_EN")
                {
                    Campaign = "ELT_Evening_0";
                }

                else if (skilltrim == "PRM_AR" || skilltrim == "PRM_EN")
                {
                    Campaign = "PRE_Evening_0";
                }

                else if (skilltrim == "COR_AR" || skilltrim == "COR_EN")
                {
                    Campaign = "COR_Evening_0";
                }

            }



            string response = CBRadd.CallBackOutboundNow(number, number, skillset, outboundskillset, "", "", Campaign, 1);
            Trace.Warn("Response of ADD To CBR" + response);


        }
        catch
        {
            string script1 = "alert('Failed To ADD to CBR');";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Info", script1, true);
        }

        string script = "alert('ADD to CBR Successfull');";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Info", script, true);
        CBR1.Enabled = false;


    }


    protected void CBR2_Click(object sender, EventArgs e)
    {
        // remove
        try
        {

            

            CBR_Services.CallBackRequest RemoveCBR = new CBR_Services.CallBackRequest();
            string number = Request.QueryString[Constants.Url_Param_CallerId];
            string skillset = Request.QueryString[Constants.Url_Param_InSkillset];
            string outboundskillset = "OB_" + skillset;

            int response = RemoveCBR.CallBackOutboundRemove("", number, "", "", "");

            Trace.Warn("Response of REMOVE FROM CBR : " + response);



        }
        catch
        {
            string script1 = "alert('Failed To Remove from CBR');";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Info", script1, true);
        }

        string script = "alert('Remove From CBR Successfull');";
        ClientScript.RegisterClientScriptBlock(this.GetType(), "Info", script, true);
    }

    protected void Credit_Click(object sender, EventArgs e)
    {
        

        string pageurl = "https://bpm.abservices.arabbank.plc/my.policy";
        Response.Write("<script> window.open('" + pageurl + "','_blank'); </script>");
    }

    protected void Approve_Click(object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection(mycon2);
        con.Open();

        ;
        string CustomerID = Request.QueryString[Constants.Url_Param_BR] + Request.QueryString[Constants.Url_Param_AcNo];
        //string windowsdomainuser = @"jordan\shatha-al";
        string lsfoorcompare = Request.QueryString[Constants.Url_Param_LS];
        string @WindowsUserName = User.Identity.Name;


        if (lsfoorcompare == "Complete Registration")
        {

            SqlCommand cmd = new SqlCommand("SP_APPROVE_TempToTin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerID", SqlDbType.NChar).Value = CustomerID;
            cmd.Parameters.Add("@RowID", SqlDbType.BigInt).Value = Request.QueryString[Constants.Url_Param_RowID];
            cmd.Parameters.Add("@NAME", SqlDbType.NVarChar).Value = "null";
            cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = 0;
            cmd.Parameters.Add("@windowsUserdomain", SqlDbType.NVarChar).Value = WindowsUserName;
            // con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            SqlCommand cmdd = new SqlCommand("SP_AGENT_NAME", con);
            cmdd.CommandType = CommandType.StoredProcedure;
            cmdd.Parameters.Add("@CustomerID", SqlDbType.NChar).Value = CustomerID;
            cmdd.Parameters.Add("@windowsUserdomain", SqlDbType.NVarChar).Value = WindowsUserName;
            cmdd.Parameters.Add("@NAME", SqlDbType.NVarChar).Value = "null";
            cmdd.Parameters.Add("@ID", SqlDbType.BigInt).Value = 0;
            con.Open();
            cmdd.ExecuteNonQuery();
            con.Close();


            string Datetimetopass = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
            string Datetopass = DateTime.Now.ToString("yyyy'-'MM'-'dd");

            string country = "JO";
            string delete = string.Empty;

            string accountbasicforws = Request.QueryString[Constants.Url_Param_BR];
            string accountnumberforws = Request.QueryString[Constants.Url_Param_AcNo];
            string ProductCodeBasedOnCountry;

            if (country == "LB")
            {
                ProductCodeBasedOnCountry = "88";
            }

            else
            {
                ProductCodeBasedOnCountry = "44";
            }


            string reqstr = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ser=\"http://AB/MW/ABSPARK/Channels/Customer/Posting/Services\" xmlns:com=\"http://AB/MW/ABSPARK/Common/Schemas/L2/Common\" xmlns:par=\"http://AB/MW/ABSPARK/Common/Schemas/L2/Party\">\n" +
            "   <soapenv:Header/>\n" +
            "   <soapenv:Body>\n" +
            "      <ser:MaintainCISCustomerProductsRequest>\n" +
            "         <Header>\n" +
            "            <!--Optional:-->\n" +
            "            <com:UUID></com:UUID>\n" +
            "            <com:Country>" + country + "</com:Country>\n" +
            "            <com:Channel>\n" +
            "               <com:ChannelName>IVR</com:ChannelName>\n" +
            "               <com:ChannelReqTime>" + Datetimetopass + "</com:ChannelReqTime>\n" +
            "               <com:ChannelTrxRef>NajwanCISproduct</com:ChannelTrxRef>\n" +
            "            </com:Channel>\n" +
            "            <com:ServiceCode>POS2035</com:ServiceCode>\n" +
            "         </Header>\n" +
            "         <CustomerIdentifier>\n" +
            "            <par:Identifier>\n" +
            "               <com:Type>AccountBranch</com:Type>\n" +
            "               <com:Value>" + accountbasicforws + "</com:Value>\n" +
            "            </par:Identifier>\n" +
            "            <par:Identifier>\n" +
            "               <com:Type>AccountBasic</com:Type>\n" +
            "               <com:Value>" + accountnumberforws + "</com:Value>\n" +
            "            </par:Identifier>\n" +
            "         </CustomerIdentifier>\n" +
            "        <IsNewRecord>true</IsNewRecord>\n" +
            "            <ProductCde>" + ProductCodeBasedOnCountry + "</ProductCde>\n" +
                     "<DeleteFlag></DeleteFlag>\n" +
            "            <LastMdfDate>" + Datetopass + "</LastMdfDate>\n" +
            "      </ser:MaintainCISCustomerProductsRequest>\n" +
            "   </soapenv:Body>\n" +
            "</soapenv:Envelope> ";








            string url = "https://10.1.13.39:9130/Customer/Posting";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.ContentType = "text/xml;charset=\"UTF-8\"";
            request.Accept = "text/xml";
            //HTTP method    
            request.Method = "POST";
            //TRN 001 Start fix for http Request 

            byte[] encod1 = Encoding.UTF8.GetBytes(reqstr);
            request.ContentLength = encod1.Length;


            //Calling CreateSOAPWebRequest method    

            XmlDocument SOAPReqBody = new XmlDocument();
            //SOAP Body Request    
            //    SOAPReqBody.LoadXml(reqstr);//requeststr1// Some parsing here
            // SOAPReqBody.LoadXml(requeststr1);//requeststr1

            Stream stream = request.GetRequestStream();
            stream.Write(encod1, 0, encod1.Length);
            stream.Close();

            //   SOAPReqBody.Save(stream);

            //Geting response from request    
            WebResponse Serviceres = request.GetResponse();
            StreamReader rd = new StreamReader(Serviceres.GetResponseStream());
            //reading stream    


            string ServiceResult = rd.ReadToEnd();
            //writting stream result on console    
            Console.WriteLine(ServiceResult);
            Console.ReadLine();
            Trace.Warn("This is the response" + ServiceResult);


            Trace.Warn("the request is:" + reqstr);



        }




        else if (lsfoorcompare == "Reactivate service")
        {


            //con.Open();
            SqlCommand cmd = new SqlCommand("SP_APPROVE_TempToTin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerID", SqlDbType.NChar).Value = CustomerID;
            cmd.Parameters.Add("@RowID", SqlDbType.BigInt).Value = Request.QueryString[Constants.Url_Param_RowID];
            cmd.Parameters.Add("@NAME", SqlDbType.NVarChar).Value = "null";
            cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = 0;
            cmd.Parameters.Add("@windowsUserdomain", SqlDbType.NVarChar).Value = WindowsUserName;

            cmd.ExecuteNonQuery();
            con.Close();






            con.Open();
            SqlCommand cmd1 = new SqlCommand("SP_LS_ReactiveService", con);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("@CustomerID", SqlDbType.NChar).Value = CustomerID;

            cmd1.ExecuteNonQuery();

            con.Close();

            con.Open();
            SqlCommand cmd2 = new SqlCommand("SP_AGENT_NAME", con);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add("@CustomerID", SqlDbType.NChar).Value = CustomerID;
            cmd2.Parameters.Add("@windowsUserdomain", SqlDbType.NVarChar).Value = WindowsUserName;
            cmd2.Parameters.Add("@NAME", SqlDbType.NVarChar).Value = "null";
            cmd2.Parameters.Add("@ID", SqlDbType.BigInt).Value = 0;

            cmd2.ExecuteNonQuery();
            con.Close();

            Trace.Warn("Reactivate service SUCCESSFUL ON APPROVE");

        }

        else if (lsfoorcompare == "Exceed Retries  Reset TIN")
        {

            SqlCommand cmd = new SqlCommand("SP_APPROVE_TempToTin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerID", SqlDbType.NChar).Value = CustomerID;
            cmd.Parameters.Add("@RowID", SqlDbType.BigInt).Value = Request.QueryString[Constants.Url_Param_RowID];
            cmd.Parameters.Add("@NAME", SqlDbType.NVarChar).Value = "null";
            cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = 0;
            cmd.Parameters.Add("@windowsUserdomain", SqlDbType.NVarChar).Value = WindowsUserName;

            cmd.ExecuteNonQuery();
            con.Close();

            SqlCommand cmd1 = new SqlCommand("SP_LS_ERResetTIN", con);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("@CustomerID", SqlDbType.NChar).Value = CustomerID;
            con.Open();
            cmd1.ExecuteNonQuery();
            con.Close();

            SqlCommand cmd2 = new SqlCommand("SP_AGENT_NAME", con);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add("@CustomerID", SqlDbType.NChar).Value = CustomerID;
            cmd2.Parameters.Add("@windowsUserdomain", SqlDbType.NVarChar).Value = WindowsUserName;
            cmd2.Parameters.Add("@NAME", SqlDbType.NVarChar).Value = "null";
            cmd2.Parameters.Add("@ID", SqlDbType.BigInt).Value = 0;
            con.Open();
            cmd2.ExecuteNonQuery();
            con.Close();

            Trace.Warn("ExceedRetriesResetTIN SUCCESSFUL ON APPROVE");
        }


        Approve.Visible = false;
        RejectSuspend.Visible = false;
        Reject.Visible = false;

        con.Close();


    }



    public void printLogs(string messgae)
    {

        System.IO.StreamWriter f = System.IO.File.CreateText("C:/Logs/Logs.log");
        f.WriteLine(messgae);


    }


    protected void Reject_Click(object sender, EventArgs e)
    {
        string customerid = Request.QueryString[Constants.Url_Param_BR] + Request.QueryString[Constants.Url_Param_AcNo];

        SqlConnection con = new SqlConnection(mycon2);
        con.Open();
        string lsfoorcompare = Request.QueryString[Constants.Url_Param_LS];
        // string windowsdomainuser = @"jordan\shatha-al";
        string @WindowsUserName = User.Identity.Name;


        if (lsfoorcompare == "Complete Registration")
        {
            SqlCommand cmd = new SqlCommand("SP_Reject", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerID", SqlDbType.NChar).Value = customerid;

            cmd.ExecuteNonQuery();
            con.Close();

            SqlCommand cmd2 = new SqlCommand("SP_AGENT_NAME", con);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add("@CustomerID", SqlDbType.NChar).Value = customerid;
            cmd2.Parameters.Add("@windowsUserdomain", SqlDbType.NVarChar).Value = WindowsUserName;
            cmd2.Parameters.Add("@NAME", SqlDbType.NVarChar).Value = "null";
            cmd2.Parameters.Add("@ID", SqlDbType.BigInt).Value = 0;
            con.Open();
            cmd2.ExecuteNonQuery();
            con.Close();

            Trace.Warn("Complete Registration SUCCESSFUL ON REJECT");

        }

        else if (lsfoorcompare == "Reactivate service" || lsfoorcompare == "Exceed Retries  Reset TIN")
        {
            SqlCommand cmd = new SqlCommand("SP_LS_ReactiveService", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerID", SqlDbType.NChar).Value = customerid;

            cmd.ExecuteNonQuery();
            con.Close();


            SqlCommand cmd2 = new SqlCommand("SP_AGENT_NAME", con);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add("@CustomerID", SqlDbType.NChar).Value = customerid;
            cmd2.Parameters.Add("@windowsUserdomain", SqlDbType.NVarChar).Value = WindowsUserName;
            cmd2.Parameters.Add("@NAME", SqlDbType.NVarChar).Value = "null";
            cmd2.Parameters.Add("@ID", SqlDbType.BigInt).Value = 0;
            con.Open();
            cmd2.ExecuteNonQuery();
            con.Close();

            Trace.Warn("reject button reactivate service done : ");
        }

        Approve.Visible = false;
        RejectSuspend.Visible = false;
        Reject.Visible = false;




    }






    protected void RejectSuspend_Click(object sender, EventArgs e)
    {
        string CustomerID = Request.QueryString[Constants.Url_Param_BR] + Request.QueryString[Constants.Url_Param_AcNo];



        SqlConnection con = new SqlConnection(mycon2);
        con.Open();
        string lsfoorcompare = Request.QueryString[Constants.Url_Param_LS];
       //string windowsdomainuser = @"jordan\shatha-al";
        string @WindowsUserName = User.Identity.Name;

        if (lsfoorcompare == "Complete Registration")
        {
            SqlCommand cmd = new SqlCommand("SP_RejectAndSuspend", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerID", SqlDbType.NChar).Value = CustomerID;
            cmd.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand("SP_AGENT_NAME", con);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add("@CustomerID", SqlDbType.NChar).Value = CustomerID;
            cmd2.Parameters.Add("@windowsUserdomain", SqlDbType.NVarChar).Value = WindowsUserName;
            cmd2.Parameters.Add("@NAME", SqlDbType.NVarChar).Value = "null";
            cmd2.Parameters.Add("@ID", SqlDbType.BigInt).Value = 0;
            cmd2.ExecuteNonQuery();
            con.Close();

        }

        else if (lsfoorcompare == "Reactivate service" || lsfoorcompare == "Exceed Retries  Reset TIN")
        {
            SqlCommand cmd = new SqlCommand("SP_LS_FSQ_TO_1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerID", SqlDbType.NChar).Value = CustomerID;
            cmd.ExecuteNonQuery();


            SqlCommand cmd2 = new SqlCommand("SP_AGENT_NAME", con);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add("@CustomerID", SqlDbType.NChar).Value = CustomerID;
            cmd2.Parameters.Add("@windowsUserdomain", SqlDbType.NVarChar).Value = WindowsUserName;
            cmd2.Parameters.Add("@NAME", SqlDbType.NVarChar).Value = "null";
            cmd2.Parameters.Add("@ID", SqlDbType.BigInt).Value = 0;
            cmd2.ExecuteNonQuery();
            con.Close();


        }

        Approve.Visible = false;
        RejectSuspend.Visible = false;
        Reject.Visible = false;


    }

}












