/**
 * Copyright 2023 Progress Software Corporation and/or one of its subsidiaries or affiliates. All rights reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
import"./kendo.html.base.js";import"./kendo.icons.js";var __meta__={id:"html.chip",name:"Html.Chip",category:"web",description:"HTML rendering utility for Kendo UI for jQuery.",depends:["html.base","icons"],features:[]};!function(e,a){var n=window.kendo,s=n.html.HTMLBase,t=s.extend({init:function(e,a){s.fn.init.call(this,e,a),this._wrapper()},options:{name:"HTMLChip",size:"medium",rounded:"medium",fillMode:"solid",themeColor:"base",attr:{},icon:"",iconClass:"",iconAttr:{},removable:!1,removableAttr:{},removeIcon:"x-circle",removeIconClass:"",content:"",text:"",actions:[],stylingOptions:["size","rounded","fillMode","themeColor"]},_wrapper:function(){var a=this,s=a.options;s.text=s.text||s.label,a.wrapper=a.element.wrap("<div class='k-chip'></div>").parent().attr(s.attr),a._addClasses(),s.icon?a.wrapper.prepend(e(n.ui.icon({icon:s.icon,size:"small",iconClass:"k-chip-icon"+(s.iconClass?` ${s.iconClass}`:"")})).attr(s.iconAttr)):s.iconClass?a.wrapper.prepend(e("<span class='"+s.iconClass+"'></span>").attr(s.iconAttr)):s.avatarClass&&a.wrapper.prepend(e("<span class='k-chip-avatar k-avatar "+s.avatarClass+"'></span>").attr(s.iconAttr)),a.element.addClass("k-chip-content"),s.text&&a.element.html('<span class="k-chip-label">'+s.text+"</span>"),!1===s.visible&&a.wrapper.addClass("k-hidden"),!0===s.selected&&a.wrapper.addClass("k-selected"),!1===s.enabled&&a.wrapper.addClass("k-disabled"),(s.actions&&s.actions.length>0||s.removable)&&a._actions()},_actions:function(){var a=this,s=a.options;if(a.actionsWrapper=e("<span class='k-chip-actions'></span>"),a.actionsWrapper.appendTo(a.wrapper),s.actions&&s.actions.length>0)for(var t=0;t<s.actions.length;t++){var i=s.actions[t];a.actionsWrapper.append(e(`<span class='k-chip-action ${i.iconClass?i.iconClass:""}'>${n.ui.icon({icon:i.icon,iconClass:"k-chip-icon"})}</span>`).attr(i.attr?i.attr:{}))}s.removable&&a.actionsWrapper.append(e(`<span class='k-chip-action k-chip-remove-action'>${n.ui.icon({icon:s.removeIcon,iconClass:"k-chip-icon"})}</span>`).attr(s.removableAttr))}});e.extend(n.html,{renderChip:function(a,n){return a&&!e.isPlainObject(a)||(n=a,a=e("<span></span>")),new t(a,n).html()},HTMLChip:t}),n.cssProperties.registerPrefix("HTMLChip","k-chip-"),n.cssProperties.registerValues("HTMLChip",[{prop:"rounded",values:n.cssProperties.roundedValues.concat([["full","full"]])}])}(window.kendo.jQuery);var kendo$1=kendo;export{kendo$1 as default};
//# sourceMappingURL=kendo.html.chip.js.map
