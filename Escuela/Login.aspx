﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Escuela.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>Nombre de Usuario</td>
                    <td>
                        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox> 
                    </td>
                </tr>
                <tr>
                    <td>Contraseña</td>
                    <td>
                        <asp:TextBox ID="txtContra" TextMode="Password" runat="server"></asp:TextBox> 
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnAcceso" runat="server" Text="Iniciar Sesion" OnClick="btnAcceso_Click" />
                    </td>
                </tr>

            </table>
        </div>
    </form>
</body>
</html>
