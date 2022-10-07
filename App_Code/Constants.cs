using System;

using System.Collections.Generic;

using System.Diagnostics;

using System.IO;
using System.Net;

using System.Text;

using System.Xml;

/// <summary>
/// Summary description for Constants
/// </summary>
public class Constants
{
    public static string Url_Param_ID = "ID";
    public static string Url_Param_Auth = "Auth";
    public static string Url_Param_CO = "CO";
    public static string Url_Param_CP = "CP";
    public static string Url_Param_AcNo = "AcNo";
    public static string Url_Param_L = "L";
    public static string Url_Param_LS = "LS";
    public static string Url_Param_Ackf = "Ackf";
    public static string Url_Param_InSkillset = "InSkillset";
    public static string Url_Param_RowID = "CR2RowID";
    public static string Url_Param_CustomerID = "CustomerID";
    public static string Url_Param_BR = "BR";
    public static string Url_Param_CT = "CT";
    public static string Url_Param_TO = "TO";
    public static string Url_Param_V = "V";
    public static string Url_Param_ContactID = "ContactID";
    public static string Url_Param_IsCall = "IsCall";
    public static string Url_Param_CallerId = "CallerId";
    public static string Customer_ID = Url_Param_BR + Url_Param_AcNo;
    public static string LS = Url_Param_LS;

    public static string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
    public static string usernmae12 = System.Security.Principal.WindowsIdentity.GetCurrent().Owner.ToString();
    public static string userName1 = System.Environment.UserName;
}

  



