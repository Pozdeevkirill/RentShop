import { Routes } from '@angular/router';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { AdminComponent } from './components/admin/admin.component';
import { RegisterComponent } from './components/admin/register/register.component';
import { LoginComponent } from './components/admin/login/login.component';
import { HomeComponent } from './components/main/home/home.component';
import { MainComponent } from './components/main/home.component';

export const routes: Routes = [
    { path: "admin", component: AdminComponent, children: [
        { path: "login", component: LoginComponent},
        { path: "register", component: RegisterComponent},
    ]},

    { path: "", component: MainComponent },
    { path: "**", component: NotFoundComponent},

];
