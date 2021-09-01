<<<<<<< Updated upstream
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { MatRadioModule } from '@angular/material/radio';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { PhaseService } from './phase.service';
import { EquipmentService } from './equipment.service';
import { SubcontractorService } from './subcontractor.service';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PhaseComponent } from './phase/phase.component';
import { SubcontractorComponent } from './subcontractor/subcontractor.component';
import { EquipmentComponent } from './equipment/equipment.component';

import { OverlayModule } from '@angular/cdk/overlay';
import { A11yModule } from '@angular/cdk/a11y';
import { BidiModule } from '@angular/cdk/bidi';
import { ObserversModule } from '@angular/cdk/observers';
import { PortalModule } from '@angular/cdk/portal';
import { MatCommonModule, MatRippleModule } from '@angular/material/core';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatRadioButton } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatSliderModule } from '@angular/material/slider';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatCardModule } from '@angular/material/card';
import { MatChipsModule } from '@angular/material/chips';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatInputModule } from '@angular/material/input';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatMenuModule } from '@angular/material/menu';
import { MatDialogModule } from '@angular/material/dialog';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatStepperModule } from '@angular/material/stepper';
import { PhaseInventoryComponent } from './phase-inventory/phase-inventory.component';
=======
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SupplierComponent } from './supplier/supplier.component';
import { TaskComponent } from './task/task.component';
import { TenderComponent } from './tender/tender.component';
import { AddEditTaskComponent } from './task/add-edit task/add-edit-task/add-edit-task.component';
import { AddEditSupplierComponent } from './supplier/add-edit-supplier/add-edit-supplier/add-edit-supplier.component';
import { FileUploadComponent } from './tender/fileUpload/file-upload/file-upload.component';
import {HttpClientModule} from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SupplierquotationComponent } from './supplier/supplierquotation/supplierquotation/supplierquotation.component';
import { CapturequotationComponent } from './supplier/supplierquotation/supplierquotation/capturequotation/capturequotation/capturequotation.component';
import { ProposedtenderComponent } from './tender/addproposedtender/proposedtender/proposedtender.component';
import { EditTaskComponent } from './task/edit task/edit-task/edit-task.component';
import { ViewtaskComponent } from './task/view task/viewtask/viewtask.component';
import { EditSupplierComponent } from './supplier/edit supplier/edit-supplier/edit-supplier.component';
import { ViewSupplierComponent } from './supplier/view supplier/view-supplier/view-supplier.component';
import { RequestquotationComponent } from './supplier/supplierquotation/requestquotation/requestquotation/requestquotation.component';
import {MatDialogModule} from '@angular/material/dialog';
import { ContactService } from './services/contact.service';
import { MatDatepickerModule} from '@angular/material/datepicker';
import { MatFormFieldModule} from '@angular/material/form-field';
import { MatInputModule} from '@angular/material/input';  
import { MatButtonModule} from '@angular/material/button';  
import { MatOptionModule } from '@angular/material/core';
import { MatMenuModule } from '@angular/material/menu';
import {MatSelectModule} from '@angular/material/select';
import {MatIconModule} from '@angular/material/icon';


>>>>>>> Stashed changes

@NgModule({
  declarations: [
    AppComponent,
<<<<<<< Updated upstream
    PhaseComponent,
    SubcontractorComponent,
    EquipmentComponent,
    PhaseInventoryComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,

    MatRadioModule,

    AppRoutingModule,
    MatAutocompleteModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatChipsModule,
    MatCheckboxModule,
    MatDatepickerModule,
    MatTableModule,
    MatDialogModule,
    MatFormFieldModule,
    MatGridListModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatMenuModule,
    MatPaginatorModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatRippleModule,
    MatSelectModule,
    MatSidenavModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatSnackBarModule,
    MatSortModule,
    MatStepperModule,
    MatToolbarModule,
    MatTooltipModule,
    OverlayModule,
    PortalModule,
    BidiModule,
    A11yModule,
    MatCommonModule,
    ObserversModule
  ],
  providers: [HttpClientModule, PhaseService, EquipmentService, SubcontractorService],
=======
    SupplierComponent,
    TaskComponent,
    TenderComponent,
    AddEditTaskComponent,
    AddEditSupplierComponent,
    FileUploadComponent,
    SupplierquotationComponent,
    CapturequotationComponent,
    ProposedtenderComponent,
    EditTaskComponent,
    ViewtaskComponent,
    EditSupplierComponent,
    ViewSupplierComponent,
    RequestquotationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    FormsModule,
    MatDialogModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatOptionModule,
    MatMenuModule,
    MatSelectModule,
    MatIconModule

  ],
  providers: [
    ContactService
  ],
>>>>>>> Stashed changes
  bootstrap: [AppComponent]
})
export class AppModule { }
