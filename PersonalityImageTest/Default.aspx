<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PersonalityImageTest.Default" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Image Personality Test</title>
    <link href="Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <main class="page-shell">
            <section class="intro">
                <p class="eyebrow">ASP.NET Web Forms Lab</p>
                <h1>First Image Personality Test</h1>
                <p>Choose the image your eyes noticed first from the updated image collection.
</p>
            </section>

            <section class="test-panel" aria-label="Personality image choices">
                <asp:Repeater ID="ImageRepeater" runat="server" OnItemCommand="ImageRepeater_ItemCommand">
                    <ItemTemplate>
                        <asp:LinkButton runat="server"
                            CssClass="image-choice"
                            CommandName="SelectImage"
                            CommandArgument='<%# Eval("Key") %>'>
                            <img src='<%# Eval("ImageUrl") %>' alt='<%# Eval("Title") %>' />
                            <span><%# Eval("Title") %></span>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:Repeater>
            </section>

            <asp:Panel ID="ResultPanel" runat="server" CssClass="result-panel" Visible="false">
                <p class="eyebrow">Your Result</p>
                <h2><asp:Literal ID="ResultTitleLiteral" runat="server" /></h2>
                <p><asp:Literal ID="ResultDescriptionLiteral" runat="server" /></p>
                <asp:Button ID="ResetButton" runat="server" Text="Try Again" CssClass="reset-button" OnClick="ResetButton_Click" />
            </asp:Panel>
        </main>
    </form>
</body>
</html>
