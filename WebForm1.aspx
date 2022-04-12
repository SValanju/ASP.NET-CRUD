<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CRUD_Table.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container my-5">
        <h3>Manage product details.</h3>
        <hr />
        <form class="my-5" runat="server">
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <div class="form-group row">
                <asp:Label ID="Label1" runat="server" Text="Label" CssClass="col-md-3">Product Name: </asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="col-md-6"></asp:TextBox>
            </div>
            <div class="form-group row">
                <asp:Label ID="Label2" runat="server" Text="Label" CssClass="col-md-3">Product Description: </asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="col-md-6"></asp:TextBox>
            </div>
            <div class="form-group row">
                <asp:Label ID="Label3" runat="server" Text="Label" CssClass="col-md-3">Product Value: </asp:Label>
                <asp:TextBox ID="TextBox3" runat="server" CssClass="col-md-6"></asp:TextBox>
            </div>
            <div class="row">
                <div class="col-md-3"></div>
                <div class="col-md-6 text-center">
                    <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" CssClass="btn btn-primary mx-5 px-5" />
                    <asp:Button ID="Button2" runat="server" Text="Update" OnClick="Button2_Click" CssClass="btn btn-primary mx-5 px-5" />
                </div>
                <div class="col-md-3">
                    <asp:Label ID="Label4" runat="server" CssClass="text-success"></asp:Label>
                    <asp:Label ID="Label5" runat="server" CssClass="text-danger"></asp:Label>
                    <asp:Label ID="Label6" runat="server" CssClass="text-danger"></asp:Label>
                </div>
            </div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" HorizontalAlign="Center" CssClass="my-5">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                    <asp:BoundField DataField="ProductDescription" HeaderText="Description" />
                    <asp:BoundField DataField="ProductValue" HeaderText="Value" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="edit" runat="server" CommandArgument='<%# Eval("ID") %>' OnClick="edit_Click">Edit</asp:LinkButton>
                            <asp:LinkButton ID="delete" runat="server" CommandArgument='<%# Eval("ID") %>' OnClick="delete_Click">Delete</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </form>
        <hr />
    </div>

</asp:Content>