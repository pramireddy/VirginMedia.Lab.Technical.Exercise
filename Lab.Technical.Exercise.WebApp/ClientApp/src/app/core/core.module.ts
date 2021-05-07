import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppService, LoggerService, ScenariosService } from './services';


@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [
    AppService,
    LoggerService,
    ScenariosService,
  ],
  exports: []
})
export class CoreModule { }
