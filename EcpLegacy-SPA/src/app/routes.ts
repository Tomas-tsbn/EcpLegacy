import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ClientsComponent } from './clients/clients.component';
import { ProjectsComponent } from './projects/projects.component';
import { ActivitiesComponent } from './activities/activities.component';
import { AuthGuard } from './_guards/auth.guard';

export const appRoutes: Routes = [
    { path: '', component: HomeComponent },
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'activities', component: ActivitiesComponent },
            { path: 'clients', component: ClientsComponent },
            { path: 'projects', component: ProjectsComponent },
        ]
    },
    { path: '**', redirectTo: '', pathMatch: 'full' },
];
