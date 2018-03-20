import { Component, ViewChild, OnInit, Inject } from '@angular/core';
import { DatePicker } from '@syncfusion/ej2-calendars';
import { Column, EditSettingsModel, ToolbarItems, IEditCell } from '@syncfusion/ej2-ng-grids';
import { DataManager, UrlAdaptor, WebApiAdaptor } from '@syncfusion/ej2-data';
import { SaveEventArgs, IRow } from '@syncfusion/ej2-grids';
import { GridComponent } from '@syncfusion/ej2-ng-grids';
import { Http } from '@angular/http';

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html'
})
export class FetchDataComponent {
    

    public data: DataManager | Object[];
    public toolbar: ToolbarItems[];
    public editSettings: Object;

    @ViewChild('grid')
    public grid: GridComponent;

    ngOnInit(): void {
        this.toolbar = ['Add', 'Edit', 'Delete', 'Update', 'Cancel'];
        this.editSettings = { allowEditing: true, allowAdding: true, allowDeleting: true};
        this.data = new DataManager({
            url: '/api/Orders',
            adaptor: new WebApiAdaptor
        }); 
    }
    
}


