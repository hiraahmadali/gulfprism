import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Company } from 'src/app/models/company.model';
import { CompanyService } from 'src/app/shared/company.service';

@Component({
  selector: 'app-add-company',
  templateUrl: './add-company.component.html',
  styleUrls: ['./add-company.component.css']
})
export class AddCompanyComponent implements OnInit {

  formModel: Company;
  constructor(
    private fb: FormBuilder,
    private companyService: CompanyService,
    private toasterService: ToastrService,
    private router: Router
  ) {
    this.formModel = new Company();
  }

  ngOnInit() {

  }

  async onSubmit(form: NgForm) {
    try{
      await this.companyService.add(this.formModel);
      this.router.navigate(['/home/company']);
    } catch(err) {
      this.toasterService.error('Company can not be added at this moment.', 'Company Add Failed.');
    }
  }

}
