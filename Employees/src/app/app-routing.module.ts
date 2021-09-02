import { AdduserComponent } from './user/adduser/adduser.component';
import { EdituserComponent } from './user/edituser/edituser.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserComponent } from './user/user.component';
/*import { TestComponent } from './test/test.component';*/

const routes: Routes = [
  {path:'adduser', component : AdduserComponent }, 
  {path:'edituser', component : EdituserComponent },
  {path:'user', component : UserComponent }]
  

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
