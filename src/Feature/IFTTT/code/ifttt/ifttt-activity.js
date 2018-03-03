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
Object.defineProperty(exports, "__esModule", { value: true });
var ma_core_1 = require("@sitecore/ma-core");
var IftttActivity = /** @class */ (function (_super) {
    __extends(IftttActivity, _super);
    function IftttActivity() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    IftttActivity.prototype.getVisual = function () {
        var subTitle = 'Trigger IFTTT';
        var cssClass = this.isDefined ? '' : 'undefined';
        return "\n            <div class=\"marketing-action " + cssClass + "\">\n                <span class=\"icon\">\n                    <img src=\"/~/icon/OfficeWhite/32x32/gearwheels.png\" />\n                </span>\n                <p class=\"text with-subtitle\" title=\"IFTTT\">\n                    IFTTT\n                    <small class=\"subtitle\" title=\"" + subTitle + "\">" + subTitle + "</small>\n                </p>\n            </div>\n        ";
    };
    Object.defineProperty(IftttActivity.prototype, "isDefined", {
        get: function () {
            return true;
        },
        enumerable: true,
        configurable: true
    });
    return IftttActivity;
}(ma_core_1.SingleItem));
exports.IftttActivity = IftttActivity;
//# sourceMappingURL=ifttt-activity.js.map