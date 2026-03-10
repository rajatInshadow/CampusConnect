export function formatDate(date: string) {
  return new Date(date).toLocaleDateString();
}

export function capitalize(text: string) {
  return text.charAt(0).toUpperCase() + text.slice(1);
}