import { Component, OnInit } from '@angular/core';
import { AccessRuleService } from './../services/access-rule/access-rule.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-access-rule',
  templateUrl: './access-rule.component.html',
  styleUrls: ['./access-rule.component.css'],
})
export class AccessRuleComponent implements OnInit {
  accessRules: any;
  submitted: boolean = false;
  success: boolean = false;
  customers: any[] = [];
  message: string = '';
  accessRuleUsers: any;
  formMode: string = 'CREATE';
  accessRuleform = new FormGroup({
    AccessRuleID: new FormControl(null),
    RuleName: new FormControl('', [
      Validators.required,
      Validators.maxLength(100),
    ]),
    Permission: new FormControl(false, Validators.required),
  });
  constructor(private AccessRuleService: AccessRuleService) {}

  ngOnInit(): void {
    this.getAccessRules();
    this.getCustomers();
  }

  getCustomers(): void {
    this.customers.push({
      customerID: 1,
      customerName: 'Gangana Lakruwan',
    });
    this.customers.push({
      customerID: 2,
      customerName: 'Chanaka Priyadarshana',
    });
    this.customers.push({
      customerID: 3,
      customerName: 'Iresha Silva',
    });
  }

  getAccessRules(): void {
    this.AccessRuleService.getAllAccessRules().subscribe(
      (res: any) => {
        this.accessRules = res;
      },
      (err) => {
        console.log(err);
      }
    );
  }

  getAccessRuleByID(ID: number): void {
    this.AccessRuleService.getAccessRuleByID(ID).subscribe(
      (res: any) => {
        this.accessRuleform.patchValue({
          AccessRuleID: res.accessRuleID,
          RuleName: res.ruleName,
          Permission: res.permission,
        });
      },
      (err) => {
        console.log(err);
      }
    );
  }

  deleteAccessRules(ID: number): void {
    this.AccessRuleService.deleteAccessRule(ID).subscribe(
      (res: any) => {
        this.resetForm();
        this.showMessage('Access rule deleted successfully!');
        this.getAccessRules();
      },
      (err) => {
        console.log(err);
      }
    );
  }
  getAccessRuleUsers(ID: number): void {
    this.AccessRuleService.getAccessRuleUsers(ID).subscribe(
      (res: any) => {
        this.accessRuleUsers = res;
      },
      (err) => {
        console.log(err);
      }
    );
  }
  viewAccessRule(ID: number): void {
    this.formMode = 'VIEW';
    this.getAccessRuleByID(ID);
    this.getAccessRuleUsers(ID);
    this.accessRuleform.disable();
  }
  updateAccessRule(ID: number): void {
    this.formMode = 'UPDATE';
    this.getAccessRuleByID(ID);
    this.accessRuleform.enable();
  }

  onFormSubmit() {
    if (this.accessRuleform.valid) {
      if (this.formMode == 'CREATE') {
        this.submitted = true;
        this.AccessRuleService.postAccessRule(
          this.accessRuleform.getRawValue()
        ).subscribe(
          (res: any) => {
            this.resetForm();
            this.getAccessRules();
            this.submitted = false;
            this.showMessage('Access rule added successfully!');
          },
          (err) => {
            console.log(err);
          }
        );
      } else if (this.formMode == 'UPDATE') {
        this.submitted = true;
        this.AccessRuleService.putAccessRule(
          this.accessRuleform.getRawValue()
        ).subscribe(
          (res: any) => {
            this.resetForm();
            this.getAccessRules();
            this.submitted = false;
            this.showMessage('Access rule updated successfully!');
          },
          (err) => {
            console.log(err);
          }
        );
      }
    }
  }

  resetForm() {
    this.accessRuleform.reset();
    this.formMode = 'CREATE';
    this.accessRuleform.enable();
  }

  getCustomer(ID: number) {
    return this.customers.filter((x: any) => x.customerID === ID)[0]
      .customerName;
  }

  showMessage(message: string) {
    this.message = message;
    this.success = true;
    setTimeout(() => {
      this.success = false;
    }, 1500);
  }
}
