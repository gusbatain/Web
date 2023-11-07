<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="WebApplication3.Pages.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../Content/bootstrap.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Section: Design Block -->
        <section class="text-center text-lg-start">
            <style>
                .cascading-right {
                    margin-right: -50px;
                }

                @media (max-width: 991.98px) {
                    .cascading-right {
                        margin-right: 0;
                    }
                }
            </style>

            <!-- Jumbotron -->
            <div class="container py-4">
                <div class="row g-0 align-items-center">
                    <div class="col-lg-6 mb-5 mb-lg-0">
                        <div class="card cascading-right" style="background: hsla(0, 0%, 100%, 0.55); backdrop-filter: blur(30px);">
                            <div class="card-body p-5 shadow-5 text-center">
                                <h2 class="fw-bold mb-5">Sign up now</h2>
                                <asp:Label ID="LabelEmpty" runat="server"
                                    Visible="false" Style="color: red;"></asp:Label>
                                <form>
                                    <!-- 2 column grid layout with text inputs for the first and last names -->
                                    <div class="row">
                                        <div class="col-md-6 mb-4">
                                            <div class="form-outline">
                                                <asp:TextBox ID="txtFname" runat="server" type="First name" class="form-control"
                                                    placeholder="First name"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col-md-6 mb-4">
                                            <div class="form-outline">
                                                <asp:TextBox ID="txtLname" runat="server" type="Last name" class="form-control"
                                                    placeholder="Last name"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>

                                    <!-- Email input -->
                                    <div class="form-outline mb-4">
                                        <asp:TextBox ID="txtEmail" runat="server" type="email" class="form-control"
                                            placeholder="Email"></asp:TextBox>

                                    </div>

                                    <!-- Password input -->
                                    <div class="form-outline mb-4">
                                        <asp:TextBox ID="txtJobtitle" runat="server"  class="form-control"
                                            placeholder="job Title"></asp:TextBox>

                                    </div>
                                    <div class="form-outline mb-4">
                                        <asp:TextBox ID="txtAdress" runat="server" class="form-control"
                                            placeholder="Adress"></asp:TextBox>

                                    </div>


                                    <!-- Checkbox -->

                                    <!-- Submit button -->

                                    <asp:Button ID="SignUp" runat="server" Text="SignUp" type="submit"
                                        class="btn btn-primary btn-block mb-4" OnClick="SignUp_Click" />

                                    <asp:Button ID="Button1" runat="server" Text="To go back" type="submit"
                                        class="btn btn-primary btn-block mb-4" OnClick="Button1_Click" />

                                    <!-- Register buttons -->
                                    <div class="text-center">
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-6 mb-5 mb-lg-0">
                        <img src="https://mdbootstrap.com/img/new/ecommerce/vertical/004.jpg" class="w-100 rounded-4 shadow-4"
                            alt="" />
                    </div>
                </div>
            </div>
            <!-- Jumbotron -->
        </section>
        <!-- Section: Design Block -->
        <div>
        </div>
    </form>
</body>
</html>
