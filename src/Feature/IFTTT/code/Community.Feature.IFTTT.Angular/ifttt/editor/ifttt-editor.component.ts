import { Component, OnInit } from '@angular/core'; // Injector
import { EditorBase } from '@sitecore/ma-core';

//import { ALERT_SERVICE, IAlertService } from '@sitecore/ma-core';
//import { TRANSLATE_SERVICE } from '@sitecore/ma-core';
//import { TranslateService } from '@ngx-translate/core';
//import { ACTIVITY_DATA_SERVICE, IActivityDataService } from '@sitecore/ma-core';
//import { SERVER_CONNECTION_SERVICE, IServerConnectionService } from '@sitecore/ma-core';

@Component({
    selector: 'ifttt-editor',
	template: `
        <section class="content">
            <div class="form-group">
                <div class="row ifttt-editor">
                    <label class="col-6 title">IFTTT editor</label>
                    <div class="col-6">
						<span class="minus-icon" (click)="decreaseValue()">-</span>
                        <input type="number" class="form-control" [(ngModel)]="count"/>
                        <span class="plus-icon" (click)="increaseValue()">+</span>
                    </div>
                </div>
            </div>
        </section>
    `
    // styles: [``]
})

export class IftttEditorComponent extends EditorBase implements OnInit {
    
    //constructor(private injector: Injector) {
    //    super();

    //    //let alertService: IAlertService = injector.get(ALERT_SERVICE);
    //    //let translateService: TranslateService = injector.get(TRANSLATE_SERVICE);
    //    //let activityDataService: IActivityDataService = injector.get(ACTIVITY_DATA_SERVICE);
    //    //let serverConnectionService: IServerConnectionService = injector.get(SERVER_CONNECTION_SERVICE);
    //}

    /**
    * Count property is bound to the input element
    */
    count: number;

    /**
    * A component lifecycle hook. Called whenever the model property or any other property in the component changes
    */
    ngOnInit(): void {
        this.count = this.model ? this.model.count || 0 : 0;
    }

    /**
    * Increases the count by 1. Bound to the '+' button
    */
    increaseValue() {
        this.count++;
    }

    /**
    * Decreases the count by 1. Bound to the '-' button
    */
    decreaseValue() {
        this.count--;
    }

    /**
    * Called when the changes in the editor are applied.
    * @returns an object that contains the values of the parameters of the activity, where each property corresponds to a parameter key.
    */
    serialize(): any {
        return {
            count: this.count
        };
    }
}