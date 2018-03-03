import { Plugin } from '@sitecore/ma-core';
import { IftttActivity } from './ifttt/ifttt-activity';
import { IftttEditorComponent } from '../codegen/ifttt/editor/ifttt-editor.component';
import { IftttModuleNgFactory } from '../codegen/ifttt/ifttt.module.ngfactory';

// Use the @Plugin decorator to define all the activities the module contains.
@Plugin({
    activityDefinitions: [
        {
            // The ID must match the ID of the activity type description definition item in the CMS.
            id: '19a80c99-e6b5-454f-8553-8c7afecc995f', 
            activity: IftttActivity,
            editorComponenet: IftttEditorComponent,
            editorModuleFactory: IftttModuleNgFactory
        }
    ]
})
export default class IftttPlugin {}
