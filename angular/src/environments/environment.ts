import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'Instamojo',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44332/',
    redirectUri: baseUrl,
    clientId: 'Instamojo_App',
    responseType: 'code',
    scope: 'offline_access Instamojo',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44332',
      rootNamespace: 'Instamojo',
    },
  },
} as Environment;
