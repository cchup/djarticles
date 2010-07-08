var TINY = {};
function getTagID(i) {
    return document.getElementById(i)
}
function getTagName(e, p) {
    p = p || document;
    return p.getElementsByTagName(e)
}
TINY.slideshow = function(n) {
    this.infoSpeed = this.imgSpeed = this.speed = 10;
    this.thumbOpacity = this.navHover = 70;
    this.navOpacity = 25;
    this.scrollSpeed = 5;
    this.letterbox = '#000';
    this.n = n;
    this.c = 0;
    this.a = [];
};
TINY.slideshow.prototype = {
    init: function(s, z, b, f, q) {
        s = getTagID(s);
        var m = getTagName('li', s),
        i = 0,
        w = 0;
        this.l = m.length;
        this.f = getTagID(z);
        this.r = getTagID(this.info);
        this.o = parseInt(TINY.style.val(z, 'width'));
        this.p = getTagID(this.thumbs);
		if (this.left && this.right) {
            var u = getTagID(this.left),
            r = getTagID(this.right);
            u.onmouseover = new Function('TINY.scroll.init("' + this.thumbs + '",-1,' + this.scrollSpeed + ')');
            u.onmouseout = r.onmouseout = new Function('TINY.scroll.cl("' + this.thumbs + '")');
            r.onmouseover = new Function('TINY.scroll.init("' + this.thumbs + '",1,' + this.scrollSpeed + ')');
        }
        for (i; i < this.l; i++) {
            this.a[i] = {};
            var h = m[i],
            a = this.a[i];
            a.t = getTagName('div', h)[0].innerHTML;
            a.l = getTagName('a', h)[0] ? getTagName('a', h)[0].href: '';
            a.p = getTagName('span', h)[0].innerHTML;
            if (this.thumbs) {
				if(this.numClass){
					var pbox = document.createElement("p");
					pbox.innerHTML = (i+1);
					var imgbox = "<span>" + pbox.innerHTML + "</span>";
				}
				else{
					var pbox = getTagName('p', h)[0];
					var g = getTagName('img', h)[0];
					var imgbox = "<span>" + g.parentNode.innerHTML + "</span>";
							
				}
				this.p.appendChild(pbox);
                w += parseInt(pbox.offsetWidth);
                if (i != this.l - 1) {
                    pbox.style.marginRight = this.spacing + 'px';
                    w += this.spacing
                }
				if (this.left && this.right) this.p.style.width = w + 'px';
				if(i != 0 && this.numClass){
					pbox.onclick = new Function(this.n + '.pr(' + i + ',1)');
				}
				else if(i != 0){
					g.style.opacity = this.thumbOpacity / 100;
					g.style.filter = 'alpha(opacity=' + this.thumbOpacity + ')';
					g.onmouseover = new Function('TINY.alpha.set(this,100,5)');
					g.onmouseout = new Function('TINY.alpha.set(this,' + this.thumbOpacity + ',5)');
					g.onclick = new Function(this.n + '.pr(' + i + ',1)');
				}
				else if(i == 0 && this.numClass){
					pbox.onclick = new Function(this.n + '.pr(' + i + ',1)');
					pbox.className=this.numClass;
				}
				else if(i == 0){
					g.style.borderColor = this.active ? this.active : '';
					g.style.opacity = this.thumbOpacity / 70;
					g.style.filter = 'alpha(opacity=100)';
					g.onmouseover = new Function('TINY.alpha.set(this,100,5)');
					g.onmouseout = new Function('TINY.alpha.set(this,' + this.thumbOpacity + ',5)');
					g.onclick = new Function(this.n + '.pr(' + i + ',1)');
					}
            }
        }
        if (b && f) {
            b = getTagID(b);
            f = getTagID(f);
            b.style.opacity = f.style.opacity = this.navOpacity / 100;
            b.style.filter = f.style.filter = 'alpha(opacity=' + this.navOpacity + ')';
            b.onmouseover = f.onmouseover = new Function('TINY.alpha.set(this,' + this.navHover + ',5)');
            b.onmouseout = f.onmouseout = new Function('TINY.alpha.set(this,' + this.navOpacity + ',5)');
            b.onclick = new Function(this.n + '.mv(-1,1)');
            f.onclick = new Function(this.n + '.mv(1,1)')
        }
        this.auto ? this.is(0, 0) : this.is(0, 1);
    },
    mv: function(d, c) {
        var t = this.c + d;
        this.c = t = t < 0 ? this.l - 1 : t > this.l - 1 ? 0 : t;
        this.pr(t, c)
    },
    pr: function(t, c) {
		var aa = this.numClass ? getTagName('p', this.p):getTagName('img', this.p);
        clearTimeout(this.lt);
        if (c) {
            clearTimeout(this.at);
			aa[t].onmouseover = new Function('TINY.alpha.set(this,100,5)');
			aa[t].onmouseout = new Function('TINY.alpha.set(this,100,5)');
			aa[t].style.borderColor = this.active ? this.active : '';
			this.at = setTimeout(new Function(this.n + '.mv(1,0)'), this.speed * 1600)
        }
        this.c = t;
        this.is(t, c);
		if(this.numClass){
			aa[t].className=this.numClass;
		}
		else{
			aa[t].style.opacity = this.thumbOpacity / 70;
			aa[t].style.filter = 'alpha(opacity=100)';
			aa[t].style.borderColor = this.active ? this.active : '';
		}
    },
    is: function(s, c) {
         if (this.info && !this.sctollTex) {
           TINY.height.set(this.r, 1, this.infoSpeed / 2, -1)
        }
        var i = new Image();
        i.style.opacity = 0;
        i.style.filter = 'alpha(opacity=0)';
        this.i = i;
        i.onload = new Function(this.n + '.le(' + s + ',' + c + ')');
        i.src = this.a[s].p;
        if (this.thumbs) {
            var a = this.numClass ? getTagName('p', this.p) : getTagName('img', this.p),
            l = a.length,
            x = 0;
            for (x; x < l; x++) {
				if(x != s && this.numClass){
					a[x].className=this.numCurClass;
					a[x].style.filter='';
				}
				else if(x!=s){
					a[x].style.borderColor = '';
					a[x].style.opacity = this.thumbOpacity / 100;
					a[x].style.filter = 'alpha(opacity=' + this.thumbOpacity + ')';
                	a[x].onmouseover = new Function('TINY.alpha.set(this,100,5)');
                	a[x].onmouseout = new Function('TINY.alpha.set(this,' + this.thumbOpacity + ',5)');
				}
            }
        }
    },
    le: function(s, c) {
        this.f.appendChild(this.i);
        var w = this.o - parseInt(this.i.offsetWidth);
        if (w > 0) {
            var l = Math.floor(w / 2);
            this.i.style.borderLeft = l + 'px solid ' + this.letterbox;
            this.i.style.borderRight = (w - l) + 'px solid ' + this.letterbox
        }
        TINY.alpha.set(this.i, 100, this.imgSpeed);
        var n = new Function(this.n + '.nf(' + s + ')');
		this.lt = this.sctollTex ? setTimeout(n,0) : setTimeout(n, this.imgSpeed * 100);
        if (!c) {
            this.at = setTimeout(new Function(this.n + '.mv(1,0)'), this.speed * 1600)
        }
        var m = getTagName('img', this.f);
        if (m.length > 2) {
            this.f.removeChild(m[0])
        }
    },
    nf: function(s) {
        if (this.info) {
            s = this.a[s];
            getTagName('div', this.r)[0].innerHTML = s.t;
			if(this.sctollTex){
				this.r.style.height = '25px';
			}
			else{
				this.r.style.height = 'auto';
				var h = parseInt(this.r.offsetHeight);	
				this.r.style.height = 0;
				TINY.height.set(this.r, h, this.infoSpeed, 0);
			}
        }
    }
};
TINY.scroll = function() {
    return {
        init: function(e, d, s) {
            e = typeof e == 'object' ? e: getTagID(e);
            var p = e.style.left || TINY.style.val(e, 'left');
            e.style.left = p;
            var l = d == 1 ? parseInt(e.offsetWidth) - parseInt(e.parentNode.offsetWidth) : 0;
            e.si = setInterval(function() {
                TINY.scroll.mv(e, l, d, s)
            },
            20)
        },
        mv: function(e, l, d, s) {
            var c = parseInt(e.style.left);
            if (c == l) {
                TINY.scroll.cl(e)
            } else {
                var i = Math.abs(l + c);
                i = i < s ? i: s;
                var n = c - i * d;
                e.style.left = n + 'px'
            }
        },
        cl: function(e) {
            e = typeof e == 'object' ? e: getTagID(e);
            clearInterval(e.si)
        }
    }
} ();
TINY.height = function() {
    return {
        set: function(e, h, s, d) {
            e = typeof e == 'object' ? e: getTagID(e);
            var oh = e.offsetHeight,
            ho = e.style.height || TINY.style.val(e, 'height');
            ho = oh - parseInt(ho);
            var hd = oh - ho > h ? -1 : 1;
            clearInterval(e.si);
            e.si = setInterval(function() {
                TINY.height.tw(e, h, ho, hd, s)
            },
            20)
        },
        tw: function(e, h, ho, hd, s) {
            var oh = e.offsetHeight - ho;
            if (oh == h) {
                clearInterval(e.si)
            } else {
                if (oh != h) {
					var h = Math.ceil(Math.abs(h - oh) / s) * hd;
                    e.style.height = ((oh + h) < 0 ? 0 : (oh + h)) + 'px'
                }
            }
        }
    }
} ();
TINY.alpha = function() {
    return {
        set: function(e, a, s) {
            e = typeof e == 'object' ? e: getTagID(e);
            var o = e.style.opacity || TINY.style.val(e, 'opacity'),
            d = a > o * 100 ? 1 : -1;
            e.style.opacity = o;
            clearInterval(e.ai);
            e.ai = setInterval(function() {
                TINY.alpha.tw(e, a, d, s)
            },
            20)
        },
        tw: function(e, a, d, s) {
            var o = Math.round(e.style.opacity * 100);
            if (o == a) {
                clearInterval(e.ai)
            } else {
                var n = o + Math.ceil(Math.abs(a - o) / s) * d;
                e.style.opacity = n / 100;
                e.style.filter = 'alpha(opacity=' + n + ')'
            }
        }
    }
} ();
TINY.style = function() {
    return {
        val: function(e, p) {
            e = typeof e == 'object' ? e: getTagID(e);
            return e.currentStyle ? e.currentStyle[p] : document.defaultView.getComputedStyle(e, null).getPropertyValue(p)
        }
    }
} ();