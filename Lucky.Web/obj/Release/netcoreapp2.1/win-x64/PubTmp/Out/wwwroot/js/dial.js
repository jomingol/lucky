!
    function (t, e) {
        "object" == typeof exports && "undefined" != typeof module ? module.exports = e() : "function" == typeof define && define.amd ? define(e) : t.LotteryDial = e()
    }(this,
        function () {
            "use strict";
            Object.assign = Object.assign ||
                function (t) {
                    if (void 0 === t || null === t) throw new TypeError("Cannot convert undefined or null to object");
                    for (var e = Object(t), n = 1; n < arguments.length; n++) {
                        var i = arguments[n];
                        if (void 0 !== i && null !== i) for (var r in i) i.hasOwnProperty(r) && (e[r] = i[r])
                    }
                    return e
                };
            var t = function (t, e) {
                if (!(t instanceof e)) throw new TypeError("Cannot call a class as a function")
            },
                e = function (t, e) {
                    if ("function" != typeof e && null !== e) throw new TypeError("Super expression must either be null or a function, not " + typeof e);
                    t.prototype = Object.create(e && e.prototype, {
                        constructor: {
                            value: t,
                            enumerable: !1,
                            writable: !0,
                            configurable: !0
                        }
                    }),
                        e && (Object.setPrototypeOf ? Object.setPrototypeOf(t, e) : t.__proto__ = e)
                },
                n = function (t, e) {
                    if (!t) throw new ReferenceError("this hasn't been initialised - super() hasn't been called");
                    return !e || "object" != typeof e && "function" != typeof e ? t : e
                },
                i = function () {
                    function e() {
                        t(this, e),
                            this._queue = []
                    }
                    return e.prototype.on = function (t, e) {
                        return this._queue[t] = this._queue[t] || [],
                            this._queue[t].push(e),
                            this
                    },
                        e.prototype.off = function (t, e) {
                            if (this._queue[t]) {
                                var n = void 0 === e ? -2 : this._queue[t].indexOf(e); - 2 === n ? delete this._queue[t] : -1 !== n && this._queue[t].splice(n, 1),
                                    this._queue[t] && 0 === this._queue[t].length && delete this._queue[t]
                            }
                            return this
                        },
                        e.prototype.has = function (t) {
                            return !!this._queue[t]
                        },
                        e.prototype.trigger = function (t) {
                            for (var e = this,
                                n = arguments.length,
                                i = Array(n > 1 ? n - 1 : 0), r = 1; r < n; r++) i[r - 1] = arguments[r];
                            return this._queue[t] && this._queue[t].forEach(function (t) {
                                return t.apply(e, i)
                            }),
                                this
                        },
                        e
                }(),
                r = function (t, e, n) {
                    if (void 0 === t.style[e]) for (var i = ["webkit", "ms", "moz", "o", null], r = 0; r < i.length; r++) {
                        var o = i[r];
                        if (!o) return null;
                        if (e = function (t) {
                            return t.replace(/-([a-z])/gi,
                                function (t, e) {
                                    return e.toUpperCase()
                                })
                        }(o + "-" + e), void 0 !== t.style[e]) break
                    }
                    return n && (t.style[e] = n),
                        e
                },
                o = 0,
                s = window.requestAnimationFrame || window.msRequestAnimationFrame || window.mozRequestAnimationFrame || window.webkitRequestAnimationFrame || window.oRequestAnimationFrame ||
                    function (t) {
                        var e = (new Date).getTime(),
                            n = Math.max(0, 16 - (e - o)),
                            i = window.setTimeout(function () {
                                t(e + n)
                            },
                                n);
                        return o = e + n,
                            i
                    },
                a = window.cancelAnimationFrame || window.msCancelAnimationFrame || window.mozCancelAnimationFrame || window.webkitCancelAnimationFrame || window.oCancelAnimationFrame ||
                    function (t) {
                        clearInterval(t)
                    };
            return function (i) {
                function o(e, r) {
                    t(this, o);
                    var s = n(this, i.call(this));
                    return s.options = Object.assign({
                        speed: 30,
                        areaNumber: 8,
                        deviation: 2
                    },
                        r),
                        s.pointer = e,
                        s.init(),
                        s
                }
                return e(o, i),
                    o.prototype.init = function () {
                        this._transform = r(this.pointer, "transform", "translate(-50%,-50%)"),
                            r(this.pointer, "backfaceVisibility", "hidden"),
                            r(this.pointer, "perspective", "1000px"),
                            this._raf = null,
                            this._runAngle = 0,
                            this._targetAngle = -1
                    },
                    o.prototype.reset = function () {
                        var t = arguments.length > 0 && void 0 !== arguments[0] ? arguments[0] : "reset";
                        this._raf && (a(this._raf), this._raf = null, this._runAngle = 0, this._targetAngle = -1, this.trigger(t), "reset" === t && r(this.pointer, this._transform, "translate(-50%,-50%) rotate(0deg)"))
                    },
                    o.prototype.setResult = function (t) {
                        var e = 360 / this.options.areaNumber,
                            n = Math.random() * e;
                        n = Math.max(this.options.deviation, n),
                            n = Math.min(e - this.options.deviation, n),
                            n = Math.ceil(n + t * e),
                            this._runAngle = 0,
                            this._targetAngle = n + 360 * (Math.floor(4 * Math.random()) + 4)
                    },
                    o.prototype.step = function () {
                        var t = this; - 1 === this._targetAngle ? this._runAngle += this.options.speed : (this._angle = (this._targetAngle - this._runAngle) / this.options.speed, this._angle = this._angle > this.options.speed ? this.options.speed : this._angle < .5 ? .5 : this._angle, this._runAngle += this._angle, this._runAngle = this._runAngle > this._targetAngle ? this._targetAngle : this._runAngle),
                            r(this.pointer, this._transform, "translate(-50%,-50%) rotate(" + this._runAngle % 360 + "deg)"),
                            this._runAngle === this._targetAngle ? this.reset("end") : this._raf = s(function () {
                                return t.step()
                            })
                    },
                    o.prototype.draw = function () {
                        var t = this;
                        this._raf || (this.has("start") && this.trigger("start"), this._angle = 0, this._raf = s(function () {
                            return t.step()
                        }))
                    },
                    o
            }(i)
        });