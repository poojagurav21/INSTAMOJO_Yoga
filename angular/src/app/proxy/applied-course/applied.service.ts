import { RestService } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { AppliedCreateOrUpdateDto, AppliedDto } from '../applied-courses/models';

@Injectable({
  providedIn: 'root',
})
export class AppliedService {
  apiName = 'Default';
  

  create = (input: AppliedCreateOrUpdateDto) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: '/api/app/applied',
      body: input,
    },
    { apiName: this.apiName });
  

  getAll = () =>
    this.restService.request<any, AppliedDto[]>({
      method: 'GET',
      url: '/api/app/applied',
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
