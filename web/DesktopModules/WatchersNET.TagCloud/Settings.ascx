<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Settings.ascx.cs" Inherits="WatchersNET.DNN.Modules.TagCloud.Settings" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="URL" Src="~/controls/URLControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke.Web" Namespace="DotNetNuke.Web.UI.WebControls" %>
<asp:panel id="pnlSettings" runat="server">
  <img style="margin: 0 auto;" src="<%= ResolveUrl("TagCloudLogo.png")%>" alt="WatchersNET.TagCloud Logo" title="WatchersNET.TagCloud Logo" />
  <div id="SettingTabs" style="width:800px;">
    <ul>
        <li><a href="#fragment-1"><asp:Label ID="lTab1" runat="server"></asp:Label></a></li>
        <li><a href="#fragment-2"><asp:Label ID="lTab2" runat="server"></asp:Label></a></li>
    </ul>
  <div id="fragment-1">
  <dnn:sectionhead id="dshCommOpt" runat="server" cssclass="Head" includerule="True" isExpanded="True" resourcekey="lCommOpt" section="tblCommOpt" />
  <table id="tblCommOpt" runat="server" style="margin-left:20px; width:100%;">
    <tr>
      <td style="width:150px;" valign="top">
        <dnn:label id="lblTagMode" runat="server"  ResourceKey="lblTagMode" controlname="rBlTagMode" suffix=":" CssClass="SubHead"></dnn:label>
      </td>
      <td>
        <asp:RadioButtonList id="rBlTagMode" runat="server" RepeatDirection="Horizontal" AutoPostBack="true">
          <asp:ListItem Text="Search Referrals" Value="referrals"></asp:ListItem>
          <asp:ListItem Selected="true" Text="Search Words" Value="search"></asp:ListItem>
          <asp:ListItem Text="Custom Tags" Value="custom"></asp:ListItem>
          <asp:ListItem Text="Taxonomy" Value="tax"></asp:ListItem>
        </asp:RadioButtonList>
      </td>
    </tr>
    <tr>
     <td valign="top">
       <dnn:label id="lblCustomTags" runat="server"  ResourceKey="lblCustomTags" controlname="tbCustomTag" suffix=":" CssClass="SubHead" Visible="false"></dnn:label>
       <dnn:label id="lblTaxMode" runat="server"  ResourceKey="lblTaxMode" controlname="dDlTaxMode" suffix=":" CssClass="SubHead" Visible="false"></dnn:label>
     </td>
     <td>
      <table id="tableVentrian" runat="server" Visible="False">
         <tr>
           <td>
             <dnn:label id="lblTabVentrian" ResourceKey="lblTabVentrian" runat="server" controlname="ddLTabsVentrian" suffix=":"></dnn:label>
           </td>
           <td>
             <asp:DropDownList id="ddLTabsVentrian" DataTextField="TabName" 
               DataValueField="TabID" runat="server" 
               onselectedindexchanged="DdLTabsSelectedIndexChanged" AutoPostBack="true">
             </asp:DropDownList>
           </td>
         </tr>
         <tr>
           <td>
             <dnn:label id="lblModuleVentrian" ResourceKey="lblModuleVentrian" runat="server" controlname="ddLModulesVentrian" suffix=":"></dnn:label>
           </td>
           <td>
             <asp:DropDownList id="ddLModulesVentrian" runat="server"></asp:DropDownList>
           </td>
         </tr>
       </table>
       <asp:CheckBoxList ID="cBlSearches" runat="server" Visible="false"></asp:CheckBoxList>
       <div>
         <dnn:label id="lblStartDate" runat="server"  ResourceKey="lblStartDate" controlname="txtStartDate" suffix=":" CssClass="SubHead" Visible="false"></dnn:label>
         <dnn:DnnTextBox id="txtStartDate" runat="server" Visible="false" />
       </div>
       <div>
         <dnn:label id="lblEndDate" runat="server"  ResourceKey="lblEndDate" controlname="txtEndDate" suffix=":" CssClass="SubHead" Visible="false"></dnn:label>
         <dnn:DnnTextBox id="txtEndDate" runat="server" Visible="false" />
       </div>
       <asp:DropDownList id="dDlTaxMode" runat="server" Visible="false" AutoPostBack="true">
       </asp:DropDownList>
       <asp:DataGrid id="grdTagList" Width="100%" runat="server" AutoGenerateColumns="False" BorderColor="Gray" BorderWidth="1px" Visible="false">
		<Columns>
			<asp:BoundColumn Visible="False" DataField="TagID" SortExpression="TagID" ReadOnly="True" HeaderText="TagID"></asp:BoundColumn>
			<asp:BoundColumn DataField="TagID" SortExpression="TagID" ReadOnly="True" HeaderText="TagID">
				<HeaderStyle HorizontalAlign="left" Width="1%" CssClass="SubHead"></HeaderStyle>
				<ItemStyle CssClass="Normal"></ItemStyle>
			</asp:BoundColumn>
			<asp:TemplateColumn>
				<HeaderStyle HorizontalAlign="Center" Width="1%" CssClass="SubHead"></HeaderStyle>
				<ItemStyle HorizontalAlign="left"></ItemStyle>
				<ItemTemplate>
					<asp:ImageButton id="btnEdit" AlternateText="Item bearbeiten" ImageUrl="~/images/edit.gif" CssClass="CommandButton"
						runat="server"></asp:ImageButton>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn>
				<HeaderStyle HorizontalAlign="Center" Width="1%" CssClass="SubHead"></HeaderStyle>
				<ItemStyle HorizontalAlign="left"></ItemStyle>
				<ItemTemplate>
					<asp:ImageButton id="btnDelete" AlternateText="Item löschen" ImageUrl="~/images/delete.gif" CssClass="CommandButton"
						runat="server"></asp:ImageButton>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:BoundColumn DataField="Tag" SortExpression="Tag" ReadOnly="True" HeaderText="Tag">
				<HeaderStyle HorizontalAlign="left" Width="10%" CssClass="SubHead"></HeaderStyle>
				<ItemStyle CssClass="Normal"></ItemStyle>
			</asp:BoundColumn>
			<asp:BoundColumn DataField="TagUrl" SortExpression="TagUrl" ReadOnly="True" HeaderText="Tag URL">
				<HeaderStyle HorizontalAlign="left" Width="10%" CssClass="SubHead"></HeaderStyle>
				<ItemStyle CssClass="Normal"></ItemStyle>
			</asp:BoundColumn>
			<asp:BoundColumn DataField="Weight" SortExpression="Weight" ReadOnly="True" HeaderText="Weight">
				<HeaderStyle HorizontalAlign="left" Width="10%" CssClass="SubHead"></HeaderStyle>
				<ItemStyle CssClass="Normal"></ItemStyle>
			</asp:BoundColumn>
		</Columns>
	</asp:DataGrid></td>
    </tr>
    <tr>
      <td></td>
      <td style="height:40px">
       <dnn:label id="lblChooseVoc" runat="server"  ResourceKey="lblChooseVoc" controlname="cBlVocabularies" suffix=":" CssClass="SubHead" Visible="false"></dnn:label>
       <asp:CheckBoxList ID="cBlVocabularies" runat="server" Visible="false"></asp:CheckBoxList>
        <asp:LinkButton id="cmdImport" runat="server" Visible="false" CssClass="CustomButton"></asp:LinkButton>
        &nbsp;<asp:LinkButton id="cmdExport" runat="server" Visible="false" CssClass="CustomButton"></asp:LinkButton>
      </td>
    </tr>
    <tr>
      <td valign="top">
        <dnn:label id="lblCustomTag" runat="server"  ResourceKey="lblCustomTag" controlname="tbCustomTag" suffix=":" CssClass="SubHead" Visible="false"></dnn:label>
        <asp:Label id="lTagId" runat="server" Visible="false"></asp:Label>
         <asp:Label id="lTagLocale" runat="server" Visible="false"></asp:Label>
      </td>
      <td>
        <table id="tCustomTag" style="width:100%;" runat="server" visible="false">
          <tr>
            <td valign="top"><asp:Label ID="lCustomTag" runat="server" Width="100px" Text="Tag Name:"></asp:Label></td>
            <td valign="top"><dnn:DnnTextBox id="tbCustomTag" runat="server" Width="194px" Visible="false" /></td>
          </tr>
          <tr>
            <td valign="top"><asp:Label ID="lTagWeight" runat="server" Text="Tag Weight:"></asp:Label></td>
            <td valign="top"><asp:DropDownList id="dDlTagWeight" runat="server" Visible="false"></asp:DropDownList></td>
          </tr>
          <tr>
            <td valign="top"><asp:Label ID="lTagUrl" runat="server" Text="Tag URL:"></asp:Label></td>
            <td valign="top">
              <dnn:url id="ctlTagUrl" runat="server" width="300" showtabs="True" showfiles="False" showUrls="True"
					urltype="F" showlog="False" shownewwindow="False" showtrack="False" Visible="false"></dnn:url>
		    </td>
          </tr>
          <tr>
            <td></td>
            <td valign="top">
              <asp:LinkButton id="iBTagAdd" runat="server" Visible="false" CssClass="CustomButton" />
              &nbsp;<asp:LinkButton id="iBTagSave" runat="server" Visible="false" CssClass="CustomButton" />
              &nbsp;<asp:LinkButton id="iBTagLocalize" runat="server" Visible="false" CssClass="CustomButton" />
            </td>
          </tr>
        </table>
        <asp:DataGrid id="grdTagLocales" Width="100%" runat="server" AutoGenerateColumns="False" BorderColor="Gray" BorderWidth="1px" Visible="false" style="margin-top:10px;">
		<Columns>
			<asp:BoundColumn Visible="False" DataField="TagID" SortExpression="TagID" ReadOnly="True" HeaderText="TagID"></asp:BoundColumn>
			<asp:BoundColumn DataField="TagID" SortExpression="TagID" ReadOnly="True" HeaderText="TagID">
				<HeaderStyle HorizontalAlign="left" Width="1%" CssClass="SubHead"></HeaderStyle>
				<ItemStyle CssClass="Normal"></ItemStyle>
			</asp:BoundColumn>
			<asp:TemplateColumn>
				<HeaderStyle HorizontalAlign="Center" Width="1%" CssClass="SubHead"></HeaderStyle>
				<ItemStyle HorizontalAlign="left"></ItemStyle>
				<ItemTemplate>
					<asp:ImageButton id="btnEdit" AlternateText="Item bearbeiten" ImageUrl="~/images/edit.gif" CssClass="CommandButton"
						runat="server"></asp:ImageButton>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn>
				<HeaderStyle HorizontalAlign="Center" Width="1%" CssClass="SubHead"></HeaderStyle>
				<ItemStyle HorizontalAlign="left"></ItemStyle>
				<ItemTemplate>
					<asp:ImageButton id="btnDelete" AlternateText="Item löschen" ImageUrl="~/images/delete.gif" CssClass="CommandButton"
						runat="server"></asp:ImageButton>
				</ItemTemplate>
			</asp:TemplateColumn>
            <asp:BoundColumn DataField="Locale" SortExpression="Locale" ReadOnly="True" HeaderText="Locale">
				<HeaderStyle HorizontalAlign="left" Width="10%" CssClass="SubHead"></HeaderStyle>
				<ItemStyle CssClass="Normal"></ItemStyle>
			</asp:BoundColumn>
			<asp:BoundColumn DataField="Tag" SortExpression="Tag" ReadOnly="True" HeaderText="Tag">
				<HeaderStyle HorizontalAlign="left" Width="10%" CssClass="SubHead"></HeaderStyle>
				<ItemStyle CssClass="Normal"></ItemStyle>
			</asp:BoundColumn>
			<asp:BoundColumn DataField="TagUrl" SortExpression="TagUrl" ReadOnly="True" HeaderText="Tag URL">
				<HeaderStyle HorizontalAlign="left" Width="10%" CssClass="SubHead"></HeaderStyle>
				<ItemStyle CssClass="Normal"></ItemStyle>
			</asp:BoundColumn>
		</Columns>
	</asp:DataGrid>
      </td>
    </tr>
    <tr>
      <td style="width:150px;" valign="top">
        <dnn:Label id="lblSkin" runat="server" ResourceKey="lblSkin" controlname="dDlSkins" suffix=":" CssClass="SubHead"></dnn:Label>
      </td>
      <td>
        <asp:DropDownList id="dDlSkins" Width="194px" runat="server"></asp:DropDownList>
      </td>
    </tr>
    <tr>
      <td style="width:150px;" valign="top">
        <dnn:label id="lblOccurCount" runat="server"  ResourceKey="lblOccurCount" controlname="tbOccurCount" suffix=":" CssClass="SubHead"></dnn:label>
      </td>
      <td>
        <dnn:DnnTextBox id="tbOccurCount" Width="50px" runat="server" />&nbsp;
        <asp:CustomValidator id="cVOccur" runat="server" OnServerValidate="CheckOccurCount" ControlToValidate="tbOccurCount" ErrorMessage="CustomValidator"></asp:CustomValidator>
      </td>
    </tr>
    <tr>
      <td style="width:150px;" valign="top">
        <dnn:label id="lblTagsCount" runat="server"  ResourceKey="lblTagsCount" controlname="tbTags" suffix=":" CssClass="SubHead"></dnn:label>
      </td>
      <td>
        <dnn:DnnTextBox id="tbTags" Width="50px" runat="server" />&nbsp;
        <asp:CustomValidator id="cVTags" runat="server" OnServerValidate="CheckTagsCount" ControlToValidate="tbTags" ErrorMessage="CustomValidator"></asp:CustomValidator>
      </td>
    </tr>
    <tr>
      <td valign="top">
        <dnn:label id="lblTagsLink" runat="server"  ResourceKey="lblTagsLink" controlname="cbTagsLink" suffix=":" CssClass="SubHead"></dnn:label>
      </td>
      <td>
        <asp:CheckBox id="cbTagsLink" Width="50px" runat="server"></asp:CheckBox>
      </td>
    </tr>
    <tr>
      <td valign="top">
        <dnn:label id="lblTagsLinkChk" runat="server"  ResourceKey="lblTagsLinkChk" controlname="cbTagsLinkChk" suffix=":" CssClass="SubHead"></dnn:label>
      </td>
      <td>
        <asp:CheckBox id="cbTagsLinkChk" Width="50px" runat="server"></asp:CheckBox>
      </td>
    </tr>
    <tr>
      <td valign="top">
        <dnn:label id="lblTagsCloudWidth" runat="server"  ResourceKey="lblTagsCloudWidth" controlname="tbTagsCloudWidth" suffix=":" CssClass="SubHead"></dnn:label>
      </td>
      <td><dnn:DnnTextBox id="tbTagsCloudWidth" Width="50px" runat="server" />&nbsp;
          <asp:DropDownList id="dDlWidth" runat="server">
            <asp:ListItem Text="%" Value="percent"></asp:ListItem>
            <asp:ListItem Text="px" Value="pixel"></asp:ListItem>
        </asp:DropDownList>&nbsp;
        <asp:CustomValidator id="cVWidth" runat="server" OnServerValidate="CheckWidth" ControlToValidate="tbTagsCloudWidth" ErrorMessage="CustomValidator"></asp:CustomValidator>
      </td>
    </tr>
    <tr>
      <td valign="top">
        <dnn:label id="lblTagsCloudHeight" runat="server"  ResourceKey="lblTagsCloudHeight" controlname="tbTagsCloudHeight" suffix=":" CssClass="SubHead"></dnn:label>
      </td>
      <td>
        <dnn:DnnTextBox id="tbTagsCloudHeight" Width="50px" runat="server" />&nbsp;
        <asp:DropDownList id="dDlHeight" runat="server">
            <asp:ListItem Text="%" Value="percent"></asp:ListItem>
            <asp:ListItem Text="px" Value="pixel"></asp:ListItem>
        </asp:DropDownList>&nbsp;
        <asp:CustomValidator id="cVHeight" runat="server" OnServerValidate="CheckHeight" ControlToValidate="tbTagsCloudHeight" ErrorMessage="CustomValidator"></asp:CustomValidator>
      </td>
    </tr>
    <tr>
      <td style="width:150px;" valign="top">
        <dnn:Label id="lblSortTags" runat="server" ResourceKey="lblSortTags" controlname="cbSortTags" suffix=":" CssClass="SubHead"></dnn:Label>
      </td>
      <td>
          <asp:CheckBox id="cbSortTags" runat="server"></asp:CheckBox>
      </td>
    </tr>
    <tr>
      <td style="width:150px;" valign="top">
        <dnn:Label id="lblTagSeparator" runat="server" ResourceKey="lblTagSeparator" controlname="txtTagSeparator" suffix=":" CssClass="SubHead"></dnn:Label>
      </td>
      <td>
          <dnn:DnnTextBox id="txtTagSeparator" runat="server" Width="194px" />
      </td>
    </tr>
    <tr>
      <td valign="top">
        <dnn:label id="lblExlusionList" runat="server"  ResourceKey="lblExlusionList" controlname="tbExlusLst" suffix=":" CssClass="SubHead"></dnn:label>
      </td>
      <td>
        <dnn:DnnTextBox id="tbExlusLst" runat="server" Width="194px" />&nbsp;<asp:ImageButton id="iBAdd" runat="server" ImageUrl="~/images/add.gif" />
      </td>
    </tr>
    <tr>
      <td></td>
      <td>
        <asp:ListBox id="lBExList" runat="server" Width="200px" ></asp:ListBox>
        <asp:ImageButton id="iBEdit" runat="server" ImageUrl="~/images/edit.gif" />
        <asp:ImageButton id="iBDelete" runat="server" ImageUrl="~/images/delete.gif" />
      </td>
    </tr>
  </table>
  </div>
  <div id="fragment-2">
  <dnn:sectionhead id="dshFlashOpt" runat="server" cssclass="Head" includerule="True" isExpanded="True" resourcekey="lFlashOpt" section="tblFlashOpt" />
  <table id="tblFlashOpt" runat="server" style="margin-left:20px; width:100%;">
    <tr>
      <td style="width:150px;" valign="top">
        <dnn:label id="lblFlashEnabled" runat="server"  ResourceKey="lblFlashEnabled" controlname="cbFlashEnabled" CssClass="SubHead"></dnn:label>
      </td>
      <td>
        <asp:Checkbox id="cbFlashEnabled" runat="server" />
      </td>
    </tr>
    <tr>
      <td style="width:150px;" valign="top">
        <dnn:label id="lblTcolor" runat="server"  ResourceKey="lblTcolor" controlname="tbTcolor" suffix=":" CssClass="SubHead"></dnn:label>
      </td>
      <td>
        #<dnn:DnnTextBox id="tbTcolor" runat="server" Width="100px" /><span id="Tcolor" class="ColorPicker"></span>&nbsp;<em><asp:Label id="lblColPic1" runat="server" Text="<--"></asp:Label></em>
        
      </td>
    </tr>
    <tr>
      <td valign="top">
        <dnn:label id="lblTcolor2" runat="server"  ResourceKey="lblTcolor2" controlname="tbTcolor2" suffix=":" CssClass="SubHead"></dnn:label>
      </td>
      <td>
        #<dnn:DnnTextBox id="tbTcolor2" runat="server" Width="100px" /><span id="Tcolor2" class="ColorPicker"></span>&nbsp;<em><asp:Label id="lblColPic2" runat="server" Text="<--"></asp:Label></em>
      </td>
    </tr>
    <tr>
      <td valign="top">
        <dnn:label id="lblHicolor" runat="server"  ResourceKey="lblHicolor" controlname="tbHicolor" suffix=":" CssClass="SubHead"></dnn:label>
      </td>
      <td>
        #<dnn:DnnTextBox id="tbHicolor" runat="server" Width="100px" /><span id="Hicolor" class="ColorPicker"></span>&nbsp;<em><asp:Label id="lblColPic3" runat="server" Text="<--"></asp:Label></em>
      </td>
    </tr>
    <tr>
      <td valign="top">
        <dnn:label id="lblBgcolor" runat="server"  ResourceKey="lblBgcolor" controlname="tbBgcolor" suffix=":" CssClass="SubHead"></dnn:label>
      </td>
      <td>
        #<dnn:DnnTextBox id="tbBgcolor" runat="server" Width="100px" /><span id="Bgcolor" class="ColorPicker"></span>&nbsp;<em><asp:Label id="lblColPic4" runat="server" Text="<--"></asp:Label></em>
      </td>
    </tr>
    <tr>
      <td valign="top">
      </td>
      <td>
        <asp:CheckBox id="cbTransparent" runat="server" TextAlign="Right" Text="&nbsp;Transparent?" AutoPostBack="true" />
      </td>
    </tr>
    <tr>
      <td valign="top">
        <dnn:label id="lblTspeed" runat="server"  ResourceKey="lblTspeed" controlname="tbTspeed" suffix=":" CssClass="SubHead"></dnn:label>
      </td>
      <td>
        <dnn:DnnTextBox id="tbTspeed" runat="server" Width="50px" />
        <asp:RangeValidator  id="rangevalidator1" runat="server" MinimumValue="25" MaximumValue="500" Type="Integer" ControlToValidate="tbTspeed" ErrorMessage="RangeValidator"></asp:RangeValidator>
      </td>
    </tr>
  </table>
  </div></div>
</asp:panel>
