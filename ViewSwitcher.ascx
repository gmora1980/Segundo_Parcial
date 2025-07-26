<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ViewSwitcher.ascx.vb" Inherits="Segundo_Parcial.ViewSwitcher" %>
<div id="viewSwitcher">
    <%: CurrentView %> view | <a href="<%: SwitchUrl %>">Switch to <%: AlternateView %></a>
</div>
