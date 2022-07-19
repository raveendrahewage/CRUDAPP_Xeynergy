import { Component, OnInit } from '@angular/core';
import { AccessRuleService } from './../services/access-rule/access-rule.service';
import { UserGroupService } from './../services/user-group/user-group.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-user-group',
  templateUrl: './user-group.component.html',
  styleUrls: ['./user-group.component.css'],
})
export class UserGroupComponent implements OnInit {
  userGroups: any;
  accessRules: any;
  submitted: boolean = false;
  success: boolean = false;
  message: string = '';
  formMode: string = 'CREATE';
  userGroupForm = new FormGroup({
    UserGroupID: new FormControl(null),
    GroupName: new FormControl('', [
      Validators.required,
      Validators.maxLength(100),
    ]),
    AccessRuleID: new FormControl(null, Validators.required),
  });
  constructor(
    private AccessRuleService: AccessRuleService,
    private UserGroupService: UserGroupService
  ) {}

  ngOnInit(): void {
    this.getUserGroups();
    this.getAccessRules();
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
  getUserGroupByID(ID: number): void {
    this.UserGroupService.getUserGroupByID(ID).subscribe(
      (res: any) => {
        this.userGroupForm.patchValue({
          UserGroupID: res.userGroupID,
          GroupName: res.groupName,
          AccessRuleID: res.accessRuleID,
        });
      },
      (err: any) => {
        console.log(err);
      }
    );
  }

  deleteUserGroup(ID: number): void {
    this.UserGroupService.deleteUserGroup(ID).subscribe(
      (res: any) => {
        this.resetForm();
        this.showMessage('User group deleted successfully!');
        this.getUserGroups();
      },
      (err: any) => {
        console.log(err);
      }
    );
  }
  viewUserGroup(ID: number): void {
    this.formMode = 'VIEW';
    this.getUserGroupByID(ID);
    this.userGroupForm.disable();
  }
  updateUserGroup(ID: number): void {
    this.formMode = 'UPDATE';
    this.getUserGroupByID(ID);
    this.userGroupForm.enable();
  }

  onFormSubmit() {
    if (this.userGroupForm.valid) {
      if (this.formMode == 'CREATE') {
        this.submitted = true;
        this.UserGroupService.postUserGroup(
          this.userGroupForm.getRawValue()
        ).subscribe(
          (res: any) => {
            this.resetForm();
            this.getUserGroups();
            this.submitted = false;
            this.showMessage('User group added successfully!');
          },
          (err: any) => {
            console.log(err);
          }
        );
      } else if (this.formMode == 'UPDATE') {
        this.submitted = true;
        this.UserGroupService.putUserGroup(
          this.userGroupForm.getRawValue()
        ).subscribe(
          (res: any) => {
            this.resetForm();
            this.getUserGroups();
            this.submitted = false;
            this.showMessage('User group updated successfully!');
          },
          (err: any) => {
            console.log(err);
          }
        );
      }
    }
  }

  resetForm() {
    this.userGroupForm.reset();
    this.formMode = 'CREATE';
    this.userGroupForm.enable();
  }

  showMessage(message: string) {
    this.message = message;
    this.success = true;
    setTimeout(() => {
      this.success = false;
    }, 1500);
  }
}
