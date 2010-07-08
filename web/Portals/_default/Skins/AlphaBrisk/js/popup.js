/* jquery popup
 */

$.jjpopup = $.jjpopup || {}
$.jjpopup.st = 0;
$.jjpopup.el = []
$.fn.popup=function(){
	 return this.each(function(){
		//check if backgroudPopup exists
		if(!document.getElementById('backgroundPopup')){
			//$(this).after('<div id="backgroundPopup"></div>')
			$(this).after('<div id="backgroundPopup" style="background:#000000;display:none;position:fixed;_position:absolute;height:100%;width:100%;top:0;left:0;background:#000000;border:0px solid #cecece;z-index:100;" onclick="disablePopups()"></div>')
		}
		
		//loads popup only if it is disabled
		if($.jjpopup.st==0){
			
			//request data for centering

			var popupHeight = $(this).height();
			var popupWidth = $(this).width();

			//request data for centering
			var windowSize = getPageDimensions();
			var windowWidth = windowSize[0];
			var windowHeight = windowSize[1];
			var pageWidth = windowSize[2];
			var pageHeight = windowSize[3];
			

			//centering
			$(this).css({
				"position": "absolute",
				"top": windowHeight/2-popupHeight/2,
				"left": windowWidth/2-popupWidth/2,
				"z-index": 10000
			});
			
			if('transparent'==$(this).css('background-color')) $(this).css('background-color','#ffffff')
			//only need force for IE6
			
			$("#backgroundPopup").css({
				"height": pageHeight,
				"width": pageWidth
			});
			
			
			//popup ...
			$("#backgroundPopup").css({
				"opacity": "0.6"
			});
			
			$("#backgroundPopup").fadeIn("fast");
			$(this).fadeIn("fast");
			$.jjpopup.el.push(this)
			$.jjpopup.st = 1;
		}
	})
}

$.fn.disablePopup=function(){
	this.each(function(){
		//disables popup only if it is enabled
		if($.jjpopup.st==1){
			$("#backgroundPopup").fadeOut("normal");
			$(this).fadeOut("normal");
			$.jjpopup.st = 0;
		}
	})
}

disablePopups = function(){
	$("#backgroundPopup").fadeOut("normal");
	for(x in $.jjpopup.el){
		$($.jjpopup.el[x]).fadeOut("normal");
	}
	$.jjpopup.st = 0;	
}

$.fn.bindPopup = function(c){
	this.each(function(){
		$(this).click(function(){
			$('#'+c).popup()
		})
	})
}

$.fn.bindClosePopup = function(){
	this.each(function(){
		$(this).click(function(){
			disablePopups()
		})
	})
}

// Get the page/window width and height
	getPageDimensions = function(){
		var xScroll, yScroll;
		
		if (window.innerHeight && window.scrollMaxY) {	
			xScroll = document.body.scrollWidth;
			yScroll = window.innerHeight + window.scrollMaxY;
		} else if (document.body.scrollHeight > document.body.offsetHeight){ // all but Explorer Mac
			xScroll = document.body.scrollWidth;
			yScroll = document.body.scrollHeight;
			
		} else { // Explorer Mac...would also work in Explorer 6 Strict, Mozilla and Safari
			if (document.body.scrollWidth && document.body.scrollWidth>document.body.offsetWidth)
			{xScroll = document.body.scrollWidth; 
			}else
			{xScroll = document.body.offsetWidth + document.body.offsetLeft; 
			}
			yScroll = document.body.offsetHeight + document.body.offsetTop; 
			
		}
		
		var windowWidth, windowHeight;
		if (self.innerHeight) {	// all except Explorer
			windowWidth = self.innerWidth;
			windowHeight = self.innerHeight;
		} else if (document.documentElement && document.documentElement.clientHeight) { // Explorer 6 Strict Mode
			windowWidth = document.documentElement.clientWidth;
			windowHeight = document.documentElement.clientHeight;
		} else if (document.body) { // other Explorers
			windowWidth = document.body.clientWidth;
			windowHeight = document.body.clientHeight;
		}	
		
		// for small pages with total height less then height of the viewport
		if(yScroll < windowHeight){
			pageHeight = windowHeight;
		} else { 
			pageHeight = yScroll;
		}
		
		// for small pages with total width less then width of the viewport
		if(xScroll < windowWidth){	
			pageWidth = windowWidth;
		} else {
			pageWidth = xScroll;
		}
		arrayPageSize = new Array(windowWidth,windowHeight,pageWidth,pageHeight) 
		return arrayPageSize;
	}