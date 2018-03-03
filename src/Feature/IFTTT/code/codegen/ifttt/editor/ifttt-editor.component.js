"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var ma_core_1 = require("@sitecore/ma-core");
var IftttEditorComponent = (function (_super) {
    __extends(IftttEditorComponent, _super);
    function IftttEditorComponent() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    IftttEditorComponent.prototype.ngOnInit = function () {
        this.count = this.model ? this.model.count || 0 : 0;
    };
    IftttEditorComponent.prototype.increaseValue = function () {
        this.count++;
    };
    IftttEditorComponent.prototype.decreaseValue = function () {
        this.count--;
    };
    IftttEditorComponent.prototype.serialize = function () {
        return {
            count: this.count
        };
    };
    IftttEditorComponent = __decorate([
        core_1.Component({
            selector: 'ifttt-editor',
            template: "\n        <section class=\"content\">\n            <div class=\"form-group\">\n                <div class=\"row ifttt-editor\">\n                    <label class=\"col-6 title\">IFTTT editor</label>\n                    <div class=\"col-6\">\n\t\t\t\t\t\t<span class=\"minus-icon\" (click)=\"decreaseValue()\">-</span>\n                        <input type=\"number\" class=\"form-control\" [(ngModel)]=\"count\"/>\n                        <span class=\"plus-icon\" (click)=\"increaseValue()\">+</span>\n                    </div>\n                </div>\n            </div>\n        </section>\n    "
        })
    ], IftttEditorComponent);
    return IftttEditorComponent;
}(ma_core_1.EditorBase));
exports.IftttEditorComponent = IftttEditorComponent;
//# sourceMappingURL=ifttt-editor.component.js.map