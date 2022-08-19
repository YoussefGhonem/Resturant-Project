export interface IEnvironmentModel {
  config?: IConfigModel;
}

export interface IConfigModel {
  production?: boolean;
  environmentName?: string;
  apiConfig?: IApiConfig;
  apiUrlIdentity?: string;
}

export interface IApiConfig {
  apiUrl?: string;
  apiVersion: 1;
}
