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
import"./kendo.core.js";import"./kendo.button.js";var __meta__={id:"togglebutton",name:"ToggleButton",category:"web",description:"The ToggleButton widget displays styled buttons with selected state.",depends:["core","button"]};!function(e,t){var o=window.kendo,s=o.ui.Button,n="click",i="toggle",l="aria-pressed",r="k-selected",d=s.extend({init:function(e,t){var n=this;s.fn.init.call(n,e,t),e=n.wrapper=n.element,t=n.options,e.addClass("k-toggle-button"),n._selected=!0===t.selected,n.toggle(n._selected),t.group&&e.attr("data-group",t.group),o.notify(n)},destroy:function(){this.wrapper.off(".kendoToggleButton"),s.fn.destroy.call(this)},events:[n,i],options:{name:"ToggleButton",group:t,selected:!1},toggle:function(e){e===t&&(e=!this._selected),this._selected=e,!0===e?(this.element.attr(l,!0),this.element.addClass(r)):!1===e&&(this.element.attr(l,!1),this.element.removeClass(r))},_click:function(e){this.options.enable&&(this.trigger(n,{event:e,id:this.element.attr("id"),target:this.element})?e.preventDefault():(this.toggle(),this.trigger(i,{event:e,checked:this._selected,group:this.options.group,id:this.element.attr("id"),target:this.element})))}});o.cssProperties.registerPrefix("ToggleButton","k-button-"),o.cssProperties.registerValues("ToggleButton",[{prop:"fillMode",values:o.cssProperties.fillModeValues.concat(["link"])},{prop:"rounded",values:o.cssProperties.roundedValues.concat([["full","full"]])}]),o.ui.plugin(d)}(window.kendo.jQuery);var kendo$1=kendo;export{kendo$1 as default};
//# sourceMappingURL=kendo.togglebutton.js.map
