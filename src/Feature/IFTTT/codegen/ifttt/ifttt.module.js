"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var forms_1 = require("@angular/forms");
var ifttt_editor_component_1 = require("./editor/ifttt-editor.component");
var IftttModule = (function () {
    function IftttModule() {
    }
    IftttModule = __decorate([
        core_1.NgModule({
            imports: [
                forms_1.FormsModule
            ],
            declarations: [ifttt_editor_component_1.IftttEditorComponent],
            entryComponents: [ifttt_editor_component_1.IftttEditorComponent]
        })
    ], IftttModule);
    return IftttModule;
}());
exports.IftttModule = IftttModule;
//# sourceMappingURL=ifttt.module.js.map