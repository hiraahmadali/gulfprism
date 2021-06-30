import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Company } from '../models/company.model';
import { CompanyService } from '../shared/company.service';

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.css']
})
export class CompanyComponent implements OnInit {
  companies: Array<Company>;
  selectedCompany: Company;
  constructor(
    private companySerice: CompanyService
  ) {
    this.companies = [];
    this.selectedCompany = new Company();
  }

  async ngOnInit() {
    this.companies = await this.companySerice.get();
    if(this.companies === null
      || typeof(this.companies) === 'undefined'
      || this.companies.length === null
      || typeof(this.companies.length) === 'undefined'
      || this.companies.length === 0 ) {
        console.log('Empty array');
        this.companies = []
      }
      console.log('this.companies', this.companies);
  }

  async viewCompany(id: number) {
    this.selectedCompany = new Company();
    this.selectedCompany = await this.companySerice.getById(id);
    console.log(id);
  }

}
