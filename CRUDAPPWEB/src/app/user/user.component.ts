import { Component, OnInit } from '@angular/core';
import { UserService } from './../services/user/user.service';
import { UserGroupService } from './../services/user-group/user-group.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ThisReceiver } from '@angular/compiler';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css'],
})
export class UserComponent implements OnInit {
  users: any;
  userGroups: any;
  submitted: boolean = false;
  success: boolean = false;
  message: string = '';
  formMode: string = 'CREATE';
  customers: any[] = [];
  userForm = new FormGroup({
    PersonID: new FormControl(null),
    FirstName: new FormControl('', [
      Validators.required,
      Validators.maxLength(100),
    ]),
    LastName: new FormControl('', [
      Validators.required,
      Validators.maxLength(100),
    ]),
    Email: new FormControl('', [
      Validators.required,
      Validators.maxLength(100),
    ]),
    AttachedCustomerID: new FormControl(null, Validators.required),
    UserGroupID: new FormControl(null, Validators.required),
  });
  constructor(
    private UserService: UserService,
    private UserGroupService: UserGroupService
  ) {}

  ngOnInit(): void {
    this.getUsers();
    this.getUserGroups();
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

  getUsers(): void {
    this.UserService.getAllUsers().subscribe(
      (res: any) => {
        this.users = res;
      },
      (err: any) => {
        console.log(err);
      }
    );
  }
  getUserGroups(): void {
    this.UserGroupService.getAllUserGroups().subscribe(
      (res: any) => {
        this.userGroups = res;
      },
      (err: any) => {
        console.log(err);
      }
    );
  }
  getUserByID(ID: number): void {
    this.UserService.getUserByID(ID).subscribe(
      (res: any) => {
        this.userForm.patchValue({
          PersonID: res.personID,
          FirstName: res.firstName,
          LastName: res.lastName,
          Email: res.email,
          AttachedCustomerID: res.attachedCustomerID,
          UserGroupID: res.userGroupID,
        });
      },
      (err: any) => {
        console.log(err);
      }
    );
  }

  deleteUser(ID: number): void {
    this.UserService.deleteUser(ID).subscribe(
      (res: any) => {
        this.resetForm();
        this.showMessage('User deleted successfully!');
        this.getUsers();
      },
      (err: any) => {
        console.log(err);
      }
    );
  }
  viewUser(ID: number): void {
    this.formMode = 'VIEW';
    this.getUserByID(ID);
    this.userForm.disable();
  }
  updateUser(ID: number): void {
    this.formMode = 'UPDATE';
    this.getUserByID(ID);
    this.userForm.enable();
  }

  onFormSubmit() {
    if (this.userForm.valid) {
      if (this.formMode == 'CREATE') {
        this.submitted = true;
        this.UserService.postUser(this.userForm.getRawValue()).subscribe(
          (res: any) => {
            this.resetForm();
            this.getUsers();
            this.submitted = false;
            this.showMessage('User added successfully!');
          },
          (err: any) => {
            console.log(err);
          }
        );
      } else if (this.formMode == 'UPDATE') {
        this.submitted = true;
        this.UserService.putUser(this.userForm.getRawValue()).subscribe(
          (res: any) => {
            this.resetForm();
            this.getUsers();
            this.submitted = false;
            this.showMessage('User updated successfully!');
          },
          (err: any) => {
            console.log(err);
          }
        );
      }
    }
  }

  getCustomer(ID: number){
    return this.customers.filter(x=>x.customerID === ID)[0].customerName;
  }

  resetForm() {
    this.userForm.reset();
    this.formMode = 'CREATE';
    // this.userForm.controls['GroupName'].enable();
    // this.userForm.controls['AccessRuleID'].enable();
  }

  showMessage(message: string) {
    this.message = message;
    this.success = true;
    setTimeout(() => {
      this.success = false;
    }, 1500);
  }
}
