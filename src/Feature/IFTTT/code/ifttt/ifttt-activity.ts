import { SingleItem } from '@sitecore/ma-core';

export class IftttActivity extends SingleItem {
	
    getVisual(): string {
        const subTitle = 'Trigger IFTTT';
        const cssClass = this.isDefined ? '' : 'undefined';
        
        return `
            <div class="marketing-action ${cssClass}">
                <span class="icon">
                    <img src="/~/icon/OfficeWhite/32x32/gearwheels.png" />
                </span>
                <p class="text with-subtitle" title="IFTTT">
                    IFTTT
                    <small class="subtitle" title="${subTitle}">${subTitle}</small>
                </p>
            </div>
        `;
    }

    get isDefined(): boolean {
        return true;
    }
}