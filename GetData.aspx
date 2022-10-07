<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GetData.aspx.cs" Inherits="GetData" Trace="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />

    <title></title>
    <style type="text/css">
        .auto-style4 {
            width: 100%;
        }

        .auto-style5 {
            width: 200px;
        }

        .auto-style6 {
            width: 200px;
            height: 41px;
        }


        #Image1 {
            margin-left: 80px;
        }

        #Label9, #Label11 {
            text-align: center;
        }


        .but div {
            visibility: hidden;
        }


        .but:hover div {
            visibility: visible;
        }

        #Credit, #Approve, #Reject, #RejectSuspend {
            margin-bottom: 4.7em;
        }

        
        .auto-style7 {
            width: 281px;
            height: 77px;
            margin-left: 30px;
        }

        
        .auto-style8 {
            width: 130px;
        }
        .auto-style9 {
            width: 130px;
            height: 41px;
        }

        #CBR:disabled{
            width:155px;
            height:37px;
            margin-bottom: 10px;
        }



        
    </style>
</head>
<body>
   <div style="background-color:#5090CC">

        <img alt="AB LOGO" class="auto-style7" src="Images/AB_JO_Logo.gif" />

   </div>
    <br />
    <br />
    <br />
    <br />
    <form id="form1" runat="server" style="margin-left: 15%">
        <div style="font-size: xx-large; font-weight: bold">
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </div>

        <table class="auto-style4">
            <tr>
                <td class="auto-style8" style="padding: 20px 0px 0px 20px">Caller ID</td>
                <td class="auto-style5" style="padding: 20px 0px 0px 20px">Language</td>
            </tr>
            <tr>
                <td aria-busy="False" class="auto-style8" style="padding: 0px 0px 0px 20px">
                    <asp:Label ID="CallerID" runat="server" BorderColor="#cccccc" BorderStyle="Solid" Height="30px" Width="80%"></asp:Label>
                </td>
                <td aria-busy="False" class="auto-style5" style="padding: 0px 0px 0px 20px">
                    <asp:Label ID="Lang" runat="server" BorderColor="#cccccc" BorderStyle="Solid" Height="30px" Width="50%"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style8" style="padding: 20px 0px 0px 20px">Customer Name</td>
                <td class="auto-style5" style="padding: 20px 0px 0px 20px">Customer ID</td>
            </tr>
            <tr>
                <td class="auto-style8" style="padding: 0px 0px 0px 20px">
                    <asp:Label ID="CusName" runat="server" BorderColor="#cccccc" BorderStyle="Solid" Height="30px" Width="80%"></asp:Label>
                </td>
                <td class="auto-style5" style="padding: 0px 0px 0px 20px">
                    <asp:Label ID="CusID" runat="server" BorderColor="#cccccc" BorderStyle="Solid" Height="30px" Width="50%"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style8" style="padding: 20px 0px 0px 20px">Account Number</td>
                <td class="auto-style5" style="padding: 20px 0px 0px 20px">Customer Type</td>
            </tr>
            <tr>
                <td class="auto-style8" style="padding: 0px 0px 0px 20px">
                    <asp:Label ID="AccNo" runat="server" BorderColor="#cccccc" BorderStyle="Solid" Height="30px" Width="80%"></asp:Label>
                </td>
                <td class="auto-style5" style="padding: 0px 0px 0px 20px">
                    <asp:Label ID="CusType" runat="server" BorderColor="#cccccc" BorderStyle="Solid" Height="30px" Width="50%"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style8" style="padding: 20px 0px 0px 20px">Country</td>
                <td class="auto-style5" style="padding: 20px 0px 0px 20px">Customer Product</td>
            </tr>
            <tr>
                <td class="auto-style8" style="padding: 0px 0px 0px 20px">
                    <asp:Label ID="Country" runat="server" BorderColor="#cccccc" BorderStyle="Solid" Height="30px" Width="80%"></asp:Label>
                </td>
                <td class="auto-style5" style="padding: 0px 0px 0px 20px">
                    <asp:Label ID="CusPro" runat="server" BorderColor="#cccccc" BorderStyle="Solid" Height="30px" Width="50%"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style8" style="padding: 20px 0px 0px 20px">Skill Set</td>
                <td class="auto-style5" style="padding: 20px 0px 0px 20px">Authentication Status</td>
            </tr>
            <tr>
                <td class="auto-style8" style="padding: 0px 0px 0px 20px">
                    <asp:Label ID="Skill" runat="server" BorderColor="#cccccc" BorderStyle="Solid" Height="30px" Width="80%"></asp:Label>
                </td>
                <td class="auto-style5" style="padding: 0px 0px 0px 20px">
                    <asp:Label ID="Auth" runat="server" BorderStyle="Solid" Height="30px" EnableTheming="True" Width="50%"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style9" style="padding: 20px 0px 0px 20px">Shift</td>
                <td class="auto-style6" style="padding: 20px 0px 0px 20px">Date</td>
            </tr>
            <tr>
                <td class="auto-style8" style="padding: 0px 0px 0px 20px">
                    <asp:DropDownList ID="DropDownShift" runat="server" Width="80%">
                        <asp:ListItem Value="1">Morning</asp:ListItem>
                        <asp:ListItem Value="2">Afternoon</asp:ListItem>
                        <asp:ListItem Value="3">Evening</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style5" style="padding: 0px 0px 0px 20px">
                    <asp:Label ID="Date" runat="server" BorderColor="#cccccc" BorderStyle="Solid" Height="30px" Width="50%"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style8" style="padding: 20px 0px 0px 20px">Secrecy Waiver Flag</td>
                <td class="auto-style5" style="padding: 20px 0px 0px 20px">Auto Callback</td>
            </tr>
            <tr>
                <td class="auto-style8" style="border-color: #CC6600; padding: 0px 0px 0px 20px; color: #FF6600;">
                    <asp:Label ID="SWF" runat="server" BorderStyle="Solid" Height="30px" Width="80%"></asp:Label>
                </td>
                <td class="auto-style5" style="padding: 0px 0px 0px 20px">
                    <asp:Label ID="AutoC" runat="server" BorderColor="#cccccc" BorderStyle="Solid" Height="30px" Width="50%"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style8" style="padding: 20px 0px 0px 20px">Last Service</td>
                <td class="auto-style5" style="padding: 20px 0px 0px 20px">Branch</td>
            </tr>
            <tr>
                <td class="auto-style8" style="padding: 0px 0px 0px 20px">
                    <asp:Label ID="Last" runat="server" BorderColor="#cccccc" BorderStyle="Solid" Height="30px" Width="80%"></asp:Label>
                </td>
                <td class="auto-style5" style="padding: 0px 0px 0px 20px">
                    <asp:Label ID="Branch" runat="server" BorderColor="#cccccc" BorderStyle="Solid" Height="30px" Width="50%"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style8" style="padding: 20px 0px 0px 20px">Comments</td>
                <td class="auto-style5" style="padding: 20px 0px 0px 20px">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8" style="padding: 0px 0px 0px 20px">
                    <asp:TextBox ID="Comments" runat="server" Height="93px" Width="80%" BorderStyle="Ridge" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td class="auto-style5" style="padding: 0px 0px 0px 20px">
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        <br />
        <br />

        
            <table style="margin-left:10px">
                <tr>
                    <td class="but">
                        <asp:Button ID="DNC" class="btn btn-primary btn-block" runat="server" Text="DNC" />
                        <div>
                            <asp:Button ID="DNC1" runat="server" class="btn btn-light" Text="Add to DNC" Width="7.5em" OnClick="DNC1_Click" /><br />
                            <asp:Button ID="DNC2" runat="server" class="btn btn-light" Text="Remove from DNC" OnClick="DNC2_Click" Width="10em" />
                        </div>
                    </td>
                    <td class="but">
                        <asp:Button ID="CBR" class="btn btn-primary btn-block" runat="server" Text="CBR"/>
                        <div>
                            <asp:Button ID="CBR1" runat="server" class="btn btn-light" Text="Add to CBR" OnClick="CBR1_Click"/><br />

                            <asp:Button ID="CBR2" runat="server" class="btn btn-light" Text="Remove from CBR" OnClick="CBR2_Click" />
                        </div>
                    </td>
                    <td>
                        <asp:Button ID="Credit" class="btn btn-primary btn-block" runat="server" Text="Credit" OnClick="Credit_Click" Style="width:100%"/>
                    </td>
                    </tr>
      
                <tr>
                    <td>
                        <asp:Button ID="Approve" class="btn btn-success btn-block" runat="server" Text="Approve" OnClick="Approve_Click" />
                    </td>
                    <td>
                        <asp:Button ID="Reject" class="btn btn-danger btn-block" runat="server" Text="Reject" OnClick="Reject_Click" />
                    </td>
                    <td>
                        <asp:Button ID="RejectSuspend" class="btn btn-danger btn-block" runat="server" Text="Reject & Suspend" OnClick="RejectSuspend_Click" />
                    </td>
                </tr>
            </table>
        
   
        <br />


    </form>
    <script src="js/popper.min.js"></script>
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
</body>
</html>
