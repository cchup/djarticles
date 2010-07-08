<%@ Control language="vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Containers.Container" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONS" Src="~/Admin/Containers/SolPartActions.ascx" %>
<script src="<%= SkinPath %>SlideShow/SlideShow.js" type="text/javascript"></script>
<div class="bannercontainer slideshow">
<div class="stl"><div class="str"><div class="st"></div></div></div>
<div class="sml"><div class="smr"><div class="sm">
		<dnn:ACTIONS runat="server" id="dnnACTIONS"  ProviderName="DNNMenuNavigationProvider" ExpandDepth="1" PopulateNodesFromClient="True" />
<ul id="slideshow">
    <li>
      <div>
      <img alt="Brisk Transparent Skin" src="<%= SkinPath %>SlideShow/banner01.png" width="350" height="220" class="img" />
      <h2>Brisk Transparent Skin</h2>
      <p><strong>Brisk Skin</strong> using the transparent png, div, CSS, JQuery etc, the skin pack can be validated with XHTML and CSS W3C standards.</p><span><% =SkinPath %>SlideShow/banner01.png</span></div></li>
    <li>
      <div>
     <img alt="Brisk Transparent Skin" src="<%= SkinPath %>SlideShow/banner02.png" width="350" height="220" class="img" />
      <h2>Client themes</h2>
      <p>The website visitors can change the webiste theme on the client through jquery client changing styles, also can change the page width layout and font size on the clients, certainly the website administrator
	can set the default theme(Skin) for the website or the page.</p><span><% =SkinPath %>SlideShow/banner02.png</span></div></li>
    <li>
      <div>
      <img alt="Brisk Transparent Skin" src="<%= SkinPath %>SlideShow/banner03.png" width="350" height="220" />
    
      <h2>Compatible Browsers</h2>
      <p>The skin has been fully tested on: IE7, IE8, Firefox, Mozilla, Netscape, Opera ,Chrome and so on, about the ie6 png and background compatibility, we provide two alternative solutions, check it here</p><span><% =SkinPath %>SlideShow/banner03.png</span></div></li>
    <li>
            <div>
      <img alt="About DnnSkin.Net" src="<%= SkinPath %>SlideShow/banner04.png" width="350" height="220" />
      <h2>Common Industry Goal</h2>
      <p>We emphasis on the use of the flexibility of the skin and containers, reasonable pane structure when we design the skin pck, coupled with the flexible bannercontainer, you can build suitable for different industries and different effects of the site</p><span><% =SkinPath %>SlideShow/banner04.png</span></div></li>
    <li><div>
      <img alt="About DnnSkin.Net" src="<%= SkinPath %>SlideShow/banner05.png" width="350" height="220" />
      <h2>About Dnnskin.net</h2>
      <p>We're perfectionists, focus on the website's accessibility and standards, we can provide professional skin design and the W3C compliant skin, trusted results in specific time frames and of course support until you’re 100% satisfied, are the main characteristics of our work.</p><span><% =SkinPath %>SlideShow/banner05.png</span></div></li></ul>
    <div id="wrapper">
        <div id="imgprev" class="imgnav" title="Previous"></div>
        <div id="imgnext" class="imgnav" title="Next"></div>
        <div id="image"></div>
        <div id="information"><div></div></div>
      <div id="thumbnails"><div id="slider"></div></div>
    </div>
<script type="text/javascript" language="javascript"> 
var slideshow=new TINY.slideshow("slideshow");
slideshow.auto=true;
slideshow.sctollTex=false;
slideshow.speed=4;
slideshow.info="information";
slideshow.thumbs="slider";
slideshow.scrollSpeed=4;
slideshow.spacing=5;
slideshow.numClass="back";
slideshow.numCurClass="currentBack";
slideshow.init("slideshow","image","imgprev","imgnext");
</script>
<div id="ContentPane" runat="server" class="contentpane"></div>
</div></div></div>
<div class="sbl"><div class="sbr"><div class="sb"></div></div></div>
</div>

