import { number } from "yup";

export function formatDate(date: string) {
  return new Date(date).toLocaleDateString();
}

export function capitalize(text: string) {
  return text.charAt(0).toUpperCase() + text.slice(1);
}

export function stringToNumber(text:string) {
  return Number(text);
}