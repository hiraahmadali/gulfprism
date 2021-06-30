import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Company } from '../models/company.model';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  constructor(private http: HttpClient) { }
  readonly BaseURI = 'http://localhost:54277/api';

  public async add(model: Company): Promise<void> {
    await this.http.post(`${this.BaseURI}/company`, model).toPromise();
  }

  public async delete(companyId: number): Promise<void> {
    await this.http.delete(`${this.BaseURI}/company/${companyId}`).toPromise();
  }

  public async get(): Promise<Array<Company>> {
    return await this.http.get<Array<Company>>(`${this.BaseURI}/company`).toPromise();
  }

  public async getById(id: number): Promise<Company> {
    return await this.http.get<Company>(`${this.BaseURI}/company/${id}`).toPromise();
  }
}
