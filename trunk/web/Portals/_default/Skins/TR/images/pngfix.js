//JS fix for PNGs in IE 5.5 and 6
        var supersleight    = function() {
            
            var root = false;
            var applyPositioning = true;
            
            // Path to a transparent GIF image
            var shim            = '<%= SkinPath %>spacer.gif';
            
            var fnLoadPngs = function() {
                if (root) {
                    root = document.getElementById(root);
                }else{
                    root = document;
                }
                for (var i = root.all.length - 1, obj = null; (obj = root.all[i]); i--) {
                    // background pngs
                    if (obj.currentStyle.backgroundImage.match(/\.png/i) !== null) {
                        bg_fnFixPng(obj);
                    }
                    // image elements
                    if (obj.tagName=='IMG' && obj.src.match(/\.png$/i) !== null){
                        el_fnFixPng(obj);
                    }
                    // apply position to 'active' elements
                    if (applyPositioning && (obj.tagName=='A' || obj.tagName=='INPUT') && obj.style.position === ''){
                        obj.style.position = 'relative';
                    }
                }
            };
        
            var bg_fnFixPng = function(obj) {
                var mode = 'scale';
                var bg    = obj.currentStyle.backgroundImage;
                var src = bg.substring(5,bg.length-2);
                if (obj.currentStyle.backgroundRepeat == 'no-repeat') {
                    mode = 'crop';
                }
                obj.style.filter = "progid:DXImageTransform.Microsoft.AlphaImageLoader(src='" + src + "', sizingMethod='" + mode + "')";
                obj.style.backgroundImage = 'url('+shim+')';
            };
        
            var el_fnFixPng = function(img) {
                var src = img.src;
                img.style.width = img.width + "px";
                img.style.height = img.height + "px";
                img.style.filter = "progid:DXImageTransform.Microsoft.AlphaImageLoader(src='" + src + "', sizingMethod='scale')";
                img.src = shim;
            };
            
            var addLoadEvent = function(func) {
                var oldonload = window.onload;
                if (typeof window.onload != 'function') {
                    window.onload = func;
                } else {
                    window.onload = function() {
                        if (oldonload) {
                            oldonload();
                        }
                        func();
                    };
                }
            };
            
            return {
                init: function() {
                    addLoadEvent(fnLoadPngs);
                },
                
                limitTo: function(el) {
                    root = el;
                },
                
                run: function() {
                    fnLoadPngs();
                }
            };
        }();
        
        // limit to part of the page ... pass an ID to limitTo:
        // supersleight.limitTo('header');
        
        supersleight.init();
		
		
		
		var arVersion = navigator.appVersion.split("MSIE")
var version = parseFloat(arVersion[1])

if ((version >= 5.5) && (document.body.filters)) 
{
   for(var i=0; i<document.images.length; i++)
   {
      var img = document.images[i]
      var imgName = img.src.toUpperCase()
      if (imgName.substring(imgName.length-3, imgName.length) == "PNG")
      {
         var imgID = (img.id) ? "id='" + img.id + "' " : ""
         var imgClass = (img.className) ? "class='" + img.className + "' " : ""
         var imgTitle = (img.title) ? "title='" + img.title + "' " : "title='" + img.alt + "' "
         var imgStyle = "display:inline-block;" + img.style.cssText 
         if (img.align == "left") imgStyle = "float:left;" + imgStyle
         if (img.align == "right") imgStyle = "float:right;" + imgStyle
         if (img.parentElement.href) imgStyle = "cursor:hand;" + imgStyle
         var strNewHTML = "<span " + imgID + imgClass + imgTitle
         + " style=\"" + "width:" + img.width + "px; height:" + img.height + "px;" + imgStyle + ";"
         + "filter:progid:DXImageTransform.Microsoft.AlphaImageLoader"
         + "(src=\'" + img.src + "\', sizingMethod='scale');\"></span>" 
         img.outerHTML = strNewHTML
         i = i-1
      }
   }
}