import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: "",
        loadChildren: () => import("./pages/login/login-module").then(m => m.LoginModule),
    },
    {
        path: "",
        loadChildren: () => import("./pages/home/home-module").then(m => m.HomeModule),
    },
    {
        path: "",
        loadChildren: () => import("./pages/bank-statement/bank-statement-module").then(m => m.BankStatementModule),
    },
    {
        path: "",
        loadChildren: () => import("./pages/credit-card/credit-card-module").then(m => m.CreditCardModule),
    },
    {
        path: "",
        loadChildren: () => import("./pages/profile/profile-module").then(m => m.ProfileModule),
    }
];
