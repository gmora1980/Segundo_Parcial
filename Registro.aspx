﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Registro.aspx.vb" Inherits="Segundo_Parcial.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card shadow-lg p-4" style="max-width: 400px; width: 100%;">
        <div class="card-body">
            <h2 class="h4 mb-3 text-center">Crear Cuenta</h2>

            <div class="form-floating">
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Name"></asp:TextBox>
                <label for="MainContent_txtNombre">Nombre</label>
            </div>
            <div class="form-floating">
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Apellido"></asp:TextBox>
                <label for="MainContent_txtApellido">Apellido</label>
            </div>

            <div class="form-floating">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="Email"></asp:TextBox>
                <label for="MainContent_txtEmail">Correo Electronico</label>
            </div>

            <div class="form-floating">
                <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>
                <label for="MainContent_txtPass">Contraseña</label>
                
            </div>
            <div class="form-floating mb-3">
                <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-select">
                    <asp:ListItem Text="Seleccione un rol" Value="0" Selected="True" />
                    <asp:ListItem Text="Administrador" Value="1" />
                    <asp:ListItem Text="Usuario Estándar" Value="2" />
                </asp:DropDownList>
                <label for="MainContent_ddlRol">Rol</label>
            </div>

            <asp:Button CssClass="btn btn-primary w-100 py-2" ID="btnRegistrar" runat="server" Text="Registrarse" OnClick="btnRegistrar_Click" />
        </div>

        <a href="Login.aspx">¿Ya estas registrado?</a>
    </div>
    <asp:Label ID="lblError" runat="server" Text="" CssClass="error"></asp:Label>

</asp:Content>
