<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:udt="DotNetNuke/UserDefinedTable" exclude-result-prefixes="udt">
  <xsl:output method="xml" indent="yes" omit-xml-declaration="yes" />
  <!--
  This prefix is used to generate module specific query strings
  Each querystring or form value that starts with udt_{ModuleId}_param 
  will be added as parameter starting with param
  -->
  <xsl:variable name="prefix_param">udt_<xsl:value-of select="//udt:Context/udt:ModuleId" />_param</xsl:variable>

  <xsl:template match="udt:Data" mode="list">
    <p class="Normal" style="padding:5px 0px 5px 0px;">
      <span class="SubHead">
        <xsl:value-of select="udt:Created_x0020_by" disable-output-escaping="yes" />
      </span>  发表于：<xsl:value-of select="udt:Created_x0020_at_UDT_Value" disable-output-escaping="yes" /><xsl:call-template name="EditLink" /><br /><xsl:value-of select="udt:我的祝福" disable-output-escaping="yes" /><br /></p>
    <hr />
  </xsl:template>

  <xsl:template match="/udt:UserDefinedTable">
    <xsl:variable name="currentData" select="udt:Data" />
    <xsl:if test="$currentData">
      <xsl:apply-templates select="$currentData" mode="list">
      </xsl:apply-templates>
    </xsl:if>
  </xsl:template>

  <xsl:template name="EditLink">
    <xsl:if test="udt:EditLink">
      <a href="{udt:EditLink}">
        <img border="0" alt="edit" src="{//udt:Context/udt:ApplicationPath}/images/edit.gif" />
      </a>
    </xsl:if>
  </xsl:template>
<udt:template listType="p" delimiter=";" listView="&lt;p class=&quot;Normal&quot; style=&quot;padding:5px 0px 5px 0px;&quot;&gt;&#xD;&#xA;&lt;span class=&quot;SubHead&quot; &gt;[Created by]&lt;/span&gt;  发表于：[Created at_UDT_Value]  [UDT:EditLink]&lt;br/&gt;&#xD;&#xA;[我的祝福]&lt;br/&gt;&#xD;&#xA;&lt;/p&gt;&#xD;&#xA;&lt;hr/&gt;" headerView="" detailView="[UDT:ListView][UDT:EditLink]&#xD;&#xA;&lt;table&gt;&#xD;&#xA;  &lt;tr&gt;&#xD;&#xA;    &lt;td class=&quot;normalBold&quot;&gt;我的祝福&lt;/td&gt;&#xD;&#xA;    &lt;td class=&quot;Normal&quot;&gt;[我的祝福]&lt;/td&gt;&#xD;&#xA;  &lt;/tr&gt;&#xD;&#xA;  &lt;tr&gt;&#xD;&#xA;    &lt;td class=&quot;normalBold&quot;&gt;Created by&lt;/td&gt;&#xD;&#xA;    &lt;td class=&quot;Normal&quot;&gt;[Created by]&lt;/td&gt;&#xD;&#xA;  &lt;/tr&gt;&#xD;&#xA;  &lt;tr&gt;&#xD;&#xA;    &lt;td class=&quot;normalBold&quot;&gt;Created at&lt;/td&gt;&#xD;&#xA;    &lt;td class=&quot;Normal&quot;&gt;[Created at_UDT_Value]&lt;/td&gt;&#xD;&#xA;  &lt;/tr&gt;&#xD;&#xA;  &lt;tr&gt;&#xD;&#xA;    &lt;td class=&quot;normalBold&quot;&gt;Changed by&lt;/td&gt;&#xD;&#xA;    &lt;td class=&quot;Normal&quot;&gt;[Changed by]&lt;/td&gt;&#xD;&#xA;  &lt;/tr&gt;&#xD;&#xA;  &lt;tr&gt;&#xD;&#xA;    &lt;td class=&quot;normalBold&quot;&gt;Changed at&lt;/td&gt;&#xD;&#xA;    &lt;td class=&quot;Normal&quot;&gt;[Changed at_UDT_Value]&lt;/td&gt;&#xD;&#xA;  &lt;/tr&gt;&#xD;&#xA;&lt;/table&gt;" trackingEmail="" />
</xsl:stylesheet>