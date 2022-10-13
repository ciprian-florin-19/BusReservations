import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import 'moment/locale/ro';
import { MaterialModule } from './material/material.module';
import { ComponentsModule } from './components/components.module';

@NgModule({
  declarations: [],
  imports: [ComponentsModule, MaterialModule],

  bootstrap: [AppComponent],
})
export class AppModule {}
