<%@ Page Title="Todos" Language="C#" Async="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Todos.aspx.cs" Inherits="WebForms.NetFx.Todos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div>
            <asp:GridView ID="DataListTodos" 
                          runat="server"
                          AutoGenerateColumns="true"
                          ItemType="ClientServices.Dtos.TodoItemDto">

            </asp:GridView>
            <br />
            <br />
            <a id="A1" runat="server" href="~/">Home</a>
        </div>
    </main>
</asp:Content>