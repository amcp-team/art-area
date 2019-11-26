import { NgModule } from '@angular/core';
import { JwtModule } from '@auth0/angular-jwt';

export function tokenGetter() {
    return localStorage.getItem("jwt");
}

@NgModule({
    imports: [
        JwtModule.forRoot({
            config: {
                tokenGetter: tokenGetter,
                whitelistedDomains: ["localhost:5000", "localhost:5001"],
                blacklistedRoutes: []
            }
        })
    ],
    exports: [JwtModule]
})
export class AppJwtModule { }