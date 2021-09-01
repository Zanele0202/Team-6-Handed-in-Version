import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddEditSupplierComponent } from './supplier/add-edit-supplier/add-edit-supplier/add-edit-supplier.component';
import { SupplierComponent } from './supplier/supplier.component';
import { AddEditTaskComponent } from './task/add-edit task/add-edit-task/add-edit-task.component';
import { TaskComponent } from './task/task.component';
import { FileUploadComponent } from './tender/fileUpload/file-upload/file-upload.component';
import { TenderComponent } from './tender/tender.component';
import { SupplierquotationComponent } from './supplier/supplierquotation/supplierquotation/supplierquotation.component';
import { AppComponent } from './app.component';
import { EditTaskComponent } from './task/edit task/edit-task/edit-task.component';
import { ViewtaskComponent } from './task/view task/viewtask/viewtask.component';
import { EditSupplierComponent } from './supplier/edit supplier/edit-supplier/edit-supplier.component';
import { ViewSupplierComponent } from './supplier/view supplier/view-supplier/view-supplier.component';
import { CapturequotationComponent } from './supplier/supplierquotation/supplierquotation/capturequotation/capturequotation/capturequotation.component';
import { RequestquotationComponent } from './supplier/supplierquotation/requestquotation/requestquotation/requestquotation.component';
import { ProposedtenderComponent } from './tender/addproposedtender/proposedtender/proposedtender.component';

const routes: Routes = [
  
  {
    path: 'task',
    component: TaskComponent,
  },
  {
    path:'add-edit-task',
    component: AddEditTaskComponent
  },
  {
    path:'edit-task',
    component: EditTaskComponent
  },
  {
    path:'viewtask',
    component: ViewtaskComponent
  },
 
  {
    path: 'supplier',
    component: SupplierComponent,
  },
  {
    path: 'add-edit-supplier',
    component: AddEditSupplierComponent
  },

  {
    path:'edit-task',
    component: EditSupplierComponent
  },

  {
    path:'view-task',
    component: ViewSupplierComponent
  },

  {
    path:'supplierquotation',
    component: SupplierquotationComponent
  },

  {
    path:'capturequotation',
    component: CapturequotationComponent
  },

  {
    path:'requestquotation',
    component: RequestquotationComponent
  },

  {
    path: 'tender',
    component: TenderComponent,
  },

  { 
    path: 'proposedtender',
    component: ProposedtenderComponent
  },

  { 
    path: 'fileUpload',
    component: FileUploadComponent
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
