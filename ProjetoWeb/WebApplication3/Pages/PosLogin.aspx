<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PosLogin.aspx.cs" Inherits="WebApplication3.Pages.PosLogin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="../Content/bootstrap.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <section style="background-color: #eee;">
            <div class="container py-5">
                <div class="row">
                    <div class="col">
                        <nav aria-label="breadcrumb" class="bg-light rounded-3 p-3 mb-4">
                            <ol class="breadcrumb mb-0">
                                <asp:LinkButton ID="Logout" runat="server" CssClass="breadcrumb-item" OnClick="Logout_Click" >Log Out</asp:LinkButton>
                            </ol>
                        </nav>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-4">
                        <div class="card mb-4">
                            <img src="https://media.licdn.com/dms/image/C4D0BAQEdw8DrtpSwlw/company-logo_200_200/0/1630550206283?e=2147483647&v=beta&t=tTRRs99pLxCzkvy-yMz8b1vojHhEejmF-Yz83nISCxg" alt="avatar" />
                            <div class="card-body text-center">
                                <div>
                                    <asp:Label ID="txtFname" runat="server" class="my-3"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="txtJobtitle" runat="server" class="text-muted mb-1"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="txtAdress" runat="server" class="text-muted mb-1"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-lg-8">
                    <div class="card mb-4">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm-3">
                                    <p class="mb-0">Full Name</p>
                                </div>
                                <div class="col-sm-9">
                                    <asp:Label ID="TxtNomeC" runat="server" CssClass="text-muted mb-0"></asp:Label>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-sm-3">
                                    <p class="mb-0">Email</p>
                                </div>
                                <div class="col-sm-9">
                                    <asp:Label ID="txtEmail" runat="server" class="text-muted mb-0"></asp:Label>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-sm-3">
                                    <p class="mb-0">Usuario</p>
                                </div>
                                <div class="col-sm-9">
                                    <asp:Label ID="txtUsuario" runat="server" class="text-muted mb-0"></asp:Label>
                                </div>
                            </div>

                        </div>
                        <hr />
                    </div>
                </div>
            </div>
            </div>
        </section>
        <div>
        </div>
    </form>
</body>
</html>
