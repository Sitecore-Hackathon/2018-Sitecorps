import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IftttEditorComponent } from './editor/ifttt-editor.component';

@NgModule({
    imports: [
        FormsModule
    ],
    declarations: [IftttEditorComponent],
    entryComponents: [IftttEditorComponent]
})
export class IftttModule { }
