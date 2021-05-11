import { Pipe, PipeTransform } from '@angular/core';
import { DecimalPipe } from '@angular/common';
import { generalParamNames } from 'src/app/config/global';

@Pipe({
  name: 'decimalnumber'
})
export class DecimalnumberPipe implements PipeTransform {
 
  MINIMO_DECIMALES = JSON.parse(localStorage.getItem(generalParamNames.MINIMO_DECIMALES));
  MAXIMO_DECIMALES = JSON.parse(localStorage.getItem(generalParamNames.MAXIMO_DECIMALES));

  transform(val) {

    try {
      let value = Number(val);
      const format = `.${this.MINIMO_DECIMALES.valor}-${this.MAXIMO_DECIMALES.valor}`; 
      return this.decimalPipe.transform(value, format);
    } catch (error) {
      return val;
    }
    
  }

  constructor(private decimalPipe: DecimalPipe) { }
  
}
