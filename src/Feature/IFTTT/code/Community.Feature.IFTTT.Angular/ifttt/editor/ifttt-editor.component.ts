import { Component, OnInit, Injector } from '@angular/core';
import { EditorBase } from '@sitecore/ma-core';

@Component({
    selector: 'ifttt-editor',
	template: `
        <section class="content">
            <div class="form-group">
                <div class="row ifttt-editor">
                    <label class="col-6 title">IFTTT editor</label>
                    <div class="col-6">
						
                    </div>
                </div>
            </div>
        </section>
    `,
    //CSS Styles are ommitted for brevity
    styles: [``]
})

export class IftttEditorComponent extends EditorBase implements OnInit {


    constructor(private injector: Injector) {
        super();
    }

    ngOnInit(): void {
        
    }

    serialize(): any {
        return {
            
        };
    }
}