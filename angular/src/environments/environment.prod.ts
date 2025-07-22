import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:44334/',
  redirectUri: baseUrl,
  clientId: 'ABPTicketProject_App',
  responseType: 'code',
  scope: 'offline_access ABPTicketProject',
  requireHttps: true,
};

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'ABPTicketProject',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44334',
      rootNamespace: 'ABPTicketProject',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
  remoteEnv: {
    url: '/getEnvConfig',
    mergeStrategy: 'deepmerge'
  }
} as Environment;
