import { APP_INITIALIZER, ApplicationConfig, importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { AuthModule, AuthService } from '@auth0/auth0-angular';
import { firstValueFrom } from 'rxjs';

const devAuthConfig = {
  domain: 'dev-bs65rtlog25jigd0.us.auth0.com',
  clientId: 'LdMw0S4EL13LvL4SZJOPRCSZo5cZJ3zD',
  authorizationParams: {
    redirect_uri: window.location.href
  }
}

function profileInitializer(
  auth: AuthService
) {
  return () => {
    return firstValueFrom(auth.isAuthenticated$).then(isAuthenticated => {
      if (!isAuthenticated) {
        auth.loginWithRedirect();
      }
    });
  }
}

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    importProvidersFrom(AuthModule.forRoot(devAuthConfig)),
    {
      provide: APP_INITIALIZER,
      useFactory: profileInitializer,
      deps: [AuthService],
      multi: true,
    }
  ]
};

