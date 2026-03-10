type InputProps = {
  label: string;
};

export default function Input({ label }: InputProps) {
  return <input>{label}</input>;
}